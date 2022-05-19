using ApplicationServices.Services.Recipes;
using ApplicationServices.Services.Recipes.Request;
using CantinaUnitBV.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUnitBV.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipesController : CantinaBvControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipesService)
    {
        _recipeService = recipesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRecipes()
    {
        var recipes = await _recipeService.GetAllRecipes();

        return Ok(recipes);
    }

    [HttpGet("{recipeId:long:required}")]
    public async Task<IActionResult> GetRecipeById([FromRoute] long recipeId)
    {
        var recipe = await _recipeService.GetRecipeById(recipeId);

        return Ok(recipe);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeRequest request)
    {
        var result = await _recipeService.AddRecipe(request);

        return FromResult(result);
    }

    [HttpPut("{recipeId:long:required}")]
    public async Task<IActionResult> UpdateRecipe([FromRoute] long recipeId, [FromBody] CreateRecipeRequest request)
    {
        var result = await _recipeService.UpdateRecipe(recipeId, request);

        return FromResult(result);
    }


    [HttpDelete("{recipeId:long:required}")]
    public async Task<IActionResult> DeleteRecipe([FromRoute] long recipeId)
    {
        var result = await _recipeService.DeleteRecipe(recipeId);

        return FromResult(result);
    }
}