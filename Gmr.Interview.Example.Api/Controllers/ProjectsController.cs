using Gmr.Interview.Example.ApplicationServices.Interfaces;
using Gmr.Interview.Example.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger;

        private readonly IProjectService _projectService;

        public ProjectsController(ILogger<ProjectsController> logger)
        {
            _logger = logger;
        }

        // GET api/projects/5
        [HttpGet("{projectId}")]
        public async Task<ProjectViewModel> GetById(int projectId)
        {
            return await _projectService.GetProjectByProjectId(projectId);
        }

        // POST api/projects
        [HttpPost]
        public async Task<ProjectViewModel> Post([FromBody] ProjectViewModel projectViewModel)
        {
            return await _projectService.CreateProject(projectViewModel);
        }

        // PUT api/projects/5
        [HttpPut("{projectId}")]
        public async Task<ProjectViewModel> Put(int projectId, [FromBody] ProjectViewModel projectViewModel)
        {
            return await _projectService.UpdateProject(projectId, projectViewModel);
        }

        // DELETE api/projects/5/HardDelete
        [HttpDelete("{projectId}/HardDelete")]
        public async Task<bool> HardDelete(int projectId)
        {
            return await _projectService.DeleteProjectHard(projectId);
        }

        // DELETE api/projects/5/SoftDelete
        [HttpDelete("{projectId}/SoftDelete")]
        public async Task<bool> SoftDelete(int projectId)
        {
            return await _projectService.DeleteProjectSoft(projectId);
        }
    }
}