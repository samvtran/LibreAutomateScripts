using System.Text.Json;
using System.Text.Json.Nodes;
using Au.Triggers;

partial class Program
{
    /// <summary>
    /// Convenient text replacements for commonly used symbols. Postfix is disabled so replacements are immediate.
    /// </summary>
    void TextReplacements(AutotextTriggers tt)
    {
        tt.DefaultPostfixType = TAPostfix.None;

        var tr = tt.SimpleReplace;

        tr[";giggle"] = "🤭";

        tt[";;zettel"] = o => o.Replace(DateTime.Now.ToString("yyyyMMddHHmmss"));
        tt[";;date"] = o => o.Replace(DateTime.Now.ToString("yyyy-MM-dd"));
        tt[";;time"] = o => o.Replace(DateTime.Now.ToString("HH:mm:ss"));

        tr[";en"] = "–";
        tr[";em"] = "—";

        tr[";guid"] = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Uses a JSON export of HTML entities provided by the <see href="https://html.spec.whatwg.org/multipage/named-characters.html">WHATWG HTML Living Standard</see>
    /// to generate a list of autotext triggers for HTML entities. All entities are lowercased and begin with <c>;</c>
    /// instead of <c>&amp;</c> to maintain consistency with the rest of the autotext triggers, but are otherwise the same as the spec.
    /// <para />
    /// Ensure <see cref="HtmlEntitiesFilePath" /> in one of your <c>Program</c> partial classes points to the html-entities.json file in this repo.
    /// </summary>
    ///
    void HTMLEntities(AutotextTriggers tt)
    {
        tt.DefaultPostfixType = TAPostfix.None;

        var tr = tt.SimpleReplace;

        var entitiesFile = File.ReadAllText(HtmlEntitiesFilePath);
        var entitiesJson = JsonNode.Parse(entitiesFile)!.AsObject();
        foreach (var entity in entitiesJson)
        {
            // Skip any variants without trailing semicolons
            if (entity.Key.Last() != ';')
            {
                continue;
            }

            var trigger = entity.Key.ReplaceAt(0, 1, ";").ToLower();
            tr[trigger] = entity.Value["characters"].ToString();
        }
    }
}
