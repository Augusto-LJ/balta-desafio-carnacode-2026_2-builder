namespace BuilderChallenge.Product;

public class SalesReport
{
    public string Title { get; set; }
    public string Format { get; internal set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IncludeHeader { get; set; }
    public bool IncludeFooter { get; set; }
    public string HeaderText { get; set; }
    public string FooterText { get; set; }
    public bool IncludeCharts { get; set; }
    public string ChartType { get; set; }
    public bool IncludeSummary { get; set; }
    public List<string> Columns { get; set; }
    public List<string> Filters { get; set; }
    public string SortBy { get; set; }
    public string GroupBy { get; set; }
    public bool IncludeTotals { get; set; }
    public string Orientation { get; set; }
    public string PageSize { get; set; }
    public bool IncludePageNumbers { get; set; }
    public string CompanyLogo { get; set; }
    public string WaterMark { get; set; }

    /// <summary>
    /// Valida se o relatório possui todas as configurações obrigatórias.
    /// Lança InvalidOperationException se alguma validação falhar.
    /// </summary>
    public void Validar()
    {
        if (string.IsNullOrWhiteSpace(Title))
            throw new InvalidOperationException("O título do relatório é obrigatório.");

        if (string.IsNullOrWhiteSpace(Format))
            throw new InvalidOperationException("O formato do relatório é obrigatório.");

        if (StartDate == default)
            throw new InvalidOperationException("A data inicial é obrigatória.");

        if (EndDate == default)
            throw new InvalidOperationException("A data final é obrigatória.");

        if (EndDate < StartDate)
            throw new InvalidOperationException("A data final não pode ser anterior à data inicial.");

        if (Columns == null || Columns.Count == 0)
            throw new InvalidOperationException("Pelo menos uma coluna deve ser definida.");

        if (IncludeHeader && string.IsNullOrWhiteSpace(HeaderText))
            throw new InvalidOperationException("O texto do cabeçalho é obrigatório quando IncludeHeader está ativado.");

        if (IncludeFooter && string.IsNullOrWhiteSpace(FooterText))
            throw new InvalidOperationException("O texto do rodapé é obrigatório quando IncludeFooter está ativado.");

        if (IncludeCharts && string.IsNullOrWhiteSpace(ChartType))
            throw new InvalidOperationException("O tipo de gráfico é obrigatório quando IncludeCharts está ativado.");
    }

    public void Gerar()
    {
        Validar();

        Console.WriteLine($"\n=== Gerando Relatório: {Title} ===");
        Console.WriteLine($"Formato: {Format}");
        Console.WriteLine($"Período: {StartDate:dd/MM/yyyy} a {EndDate:dd/MM/yyyy}");

        if (IncludeHeader)
            Console.WriteLine($"Cabeçalho: {HeaderText}");

        if (IncludeCharts)
            Console.WriteLine($"Gráfico: {ChartType}");

        Console.WriteLine($"Colunas: {string.Join(", ", Columns)}");

        if (Filters != null && Filters.Count > 0)
            Console.WriteLine($"Filtros: {string.Join(", ", Filters)}");

        if (!string.IsNullOrWhiteSpace(SortBy))
            Console.WriteLine($"Ordenado por: {SortBy}");

        if (!string.IsNullOrWhiteSpace(GroupBy))
            Console.WriteLine($"Agrupado por: {GroupBy}");

        Console.WriteLine($"Inclui Totais: {(IncludeTotals ? "Sim" : "Não")}");
        Console.WriteLine($"Inclui Resumo: {(IncludeSummary ? "Sim" : "Não")}");
        Console.WriteLine($"Orientação: {Orientation}");
        Console.WriteLine($"Tamanho da página: {PageSize}");
        Console.WriteLine($"Inclui números de página: {(IncludePageNumbers ? "Sim" : "Não")}");
        Console.WriteLine($"Logo da empresa: {CompanyLogo}");
        Console.WriteLine($"Marca d'água: {WaterMark}");

        if (IncludeFooter)
            Console.WriteLine($"Conteúdo do rodapé: {FooterText}");

        Console.WriteLine("Relatório gerado com sucesso!");
    }
}