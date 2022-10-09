using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels.ProjectDTOs;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProjectController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("shortList")]
        public async Task<IActionResult> GetShortListAsync()
        {
            var result = await _serviceManager.ProjectService.GetAllAsync<ShortProjectDTO>();
            return Ok(result);
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetDetailedAsync([FromRoute] int projectId)
        {
            var result = await _serviceManager.ProjectService.GetByIdAsync<DetailedProjectDTO>(projectId);
            return Ok(result);
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProjectAsync([FromRoute] int projectId)
        {
            await _serviceManager.ProjectService.DeleteByIdAsync(projectId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectAsync([FromBody] UpdateCreateProjectDTO model)
        {
            var result = await _serviceManager.ProjectService.CreateAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProjectAsync([FromBody] UpdateCreateProjectDTO model)
        {
            await _serviceManager.ProjectService.UpdateAsync(model);
            return Ok();
        }
    }
}
