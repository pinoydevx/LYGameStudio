using Microsoft.AspNetCore.Mvc;
using LYStudio.Models;
using LYStudio.Services;

namespace LYStudio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _profilesService;

        public ProfilesController(ProfilesService profilesService) =>
            _profilesService = profilesService;

        [HttpGet]
        public async Task<List<Profile>> Get() =>
            await _profilesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Profile>> Get(string id)
        {
            var book = await _profilesService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Profile newProfile)
        {
            await _profilesService.CreateAsync(newProfile);

            return CreatedAtAction(nameof(Get), new { id = newProfile.Id }, newProfile);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Profile updatedProfile)
        {
            var book = await _profilesService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedProfile.Id = book.Id;

            await _profilesService.UpdateAsync(id, updatedProfile);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _profilesService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _profilesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
