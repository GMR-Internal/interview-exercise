using AutoMapper;
using AutoMapper.Configuration;
using Gmr.Interview.Example.ApplicationServices.Interfaces;
using Gmr.Interview.Example.DomainModels;
using Gmr.Interview.Example.DomainServices.Repositories;
using Gmr.Interview.Example.ViewModels;
using Serilog;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.ApplicationServices.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ILogger _logger = Log.ForContext<ProjectService>();
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IRepository<Project> _projectRepository;

        public ProjectService(IMapper mapper, IConfiguration configuration, IRepository<Project> projectRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _projectRepository = projectRepository;
        }

        public async Task<ProjectViewModel> GetProjectByProjectId(int projectId)
        {
            var project = await _projectRepository.FirstOrDefaultAsync(x => x.ProjectId == projectId);

            return _mapper.Map<ProjectViewModel>(project);
        }

        public async Task<ProjectViewModel> CreateProject(ProjectViewModel projectViewModel)
        {
            var project = _mapper.Map<Project>(projectViewModel);

            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();

            return projectViewModel;
        }

        public async Task<ProjectViewModel> UpdateProject(int projectId, ProjectViewModel projectViewModel)
        {
            var updatedProject = _projectRepository.UpdateAsync(_mapper.Map<Project>(projectViewModel));

            await _projectRepository.SaveChangesAsync();

            return projectViewModel;
        }

        public async Task<bool> DeleteProjectHard(int projectId)
        {
            var project = await _projectRepository.FirstOrDefaultAsync(x => x.ProjectId == projectId);

            await _projectRepository.DeleteAsync(project);

            return await _projectRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProjectSoft(int projectId)
        {
            var project = await _projectRepository.FirstOrDefaultAsync(x => x.ProjectId == projectId);

            if (project != null)
            {
                project.IsDeleted = true;

                await _projectRepository.UpdateAsync(project);

                return await _projectRepository.SaveChangesAsync() > 0;
            }

            return true;
        }
    }
}