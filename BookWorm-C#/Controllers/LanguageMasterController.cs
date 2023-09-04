using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookWorm_C_.Services;
using BookWorm_C_.Entities;

namespace BookWorm_C_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageMasterController : ControllerBase
    {
        private readonly LanguageMasterService _languageMasterService;

        public LanguageMasterController(LanguageMasterService languageMasterService)
        {
            _languageMasterService = languageMasterService;
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateLanguage(long id, [FromBody] LanguageMaster language)
        {
            _languageMasterService.UpdateLanguage(id, language);
            return Ok("Language updated successfully");
        }

        [HttpGet("getAll")]
        public ActionResult<List<LanguageMaster>> GetAllLanguages()
        {
            var languages = _languageMasterService.GetAllLanguages();
            return Ok(languages);
        }

        [HttpGet("getById/{id}")]
        public ActionResult<LanguageMaster> GetLanguageById(long id)
        {
            var language = _languageMasterService.GetLanguageById(id);
            if (language == null)
            {
                return NotFound();
            }
            return Ok(language);
        }

        [HttpGet("getByType/{type}")]
        public ActionResult<LanguageMaster> GetLanguageByType(string type)
        {
            var language = _languageMasterService.GetLanguageByType(type);
            if (language == null)
            {
                return NotFound();
            }
            return Ok(language);
        }

        // Add other actions as needed
    }
}