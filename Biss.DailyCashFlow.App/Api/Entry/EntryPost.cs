using Biss.DailyCashFlow.Service.Interface;

namespace Biss.DailyCashFlow.App.Api.Entry;
public class EntryPost
{
    public static string Template => "/entry";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(EntryRequest request, IEntryService service)
    {
        if (string.IsNullOrEmpty(request.Description))
        {
            return Results.BadRequest("A descrição do lançamento é obrigatória.");
        }

        if (request.Value == 0)
        {
            return Results.BadRequest("O valor do lançamento deve ser informado.");
        }

        Domain.Entities.Entry entity = request.ToEntity();
       
        await service.AddEntryAsync(entity);
        return Results.Created($"/{Template}/{entity.Id}", "Lançamento adicionado com sucesso");
    }
}
