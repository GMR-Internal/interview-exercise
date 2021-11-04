using Gmr.Interview.Example.DomainModels;
using Gmr.Interview.Example.ViewModels;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.ApplicationServices.Interfaces
{
    public interface IProjectService
    {
        public Task<ProjectViewModel> GetProjectByProjectId(int projectId);

        public Task<ProjectViewModel> CreateProject(ProjectViewModel projectViewModel);

        public Task<ProjectViewModel> UpdateProject(int projectId, ProjectViewModel projectViewModel);

        public Task<bool> DeleteProjectHard(int projectId);

        public Task<bool> DeleteProjectSoft(int projectId);
    }
}