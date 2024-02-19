using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using Microsoft.Extensions.Configuration;

namespace ChatGPT_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GptController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public GptController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("UseChatGpt")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            string OutputResult = "";

            // Retrieve your OpenAI API key from configuration
            string apiKey = _configuration["OpenAIApiKey"];

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return BadRequest("OpenAI API key is missing or invalid in the configuration.");
            }

            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completionRequest = new CompletionRequest
            {
                Prompt = query,
                Model = "davinci",
            };

            var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Completions)
            {
                OutputResult += completion.Text;
            }

            return Ok(OutputResult);
        }
    }
}





//var openai = new OpenAIAPI("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");
//var openai = new OpenAIAPI("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");
//var openai = new OpenAIAPI("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");