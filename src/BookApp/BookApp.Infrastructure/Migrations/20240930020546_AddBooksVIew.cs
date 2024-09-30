using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBooksVIew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                            CREATE VIEW vw_Detailed_Books AS
                            SELECT 
                                l.Titulo as Title,
                                l.Edicao as Edition,
                                l.AnoPublicacao as YearPublication,
                                (
                                    SELECT STRING_AGG(a.Nome, ', ')
                                    FROM Autor a
                                    INNER JOIN Livro_Autor la ON la.Autor_CodAu = a.CodAu
                                    WHERE la.Livro_Codl = l.Codl
                                ) AS Authors,
                                (
                                    SELECT STRING_AGG(s.Descricao, ', ')
                                    FROM Assunto s
                                    INNER JOIN Livro_Assunto ls ON ls.Assunto_CodAs = s.CodAs
                                    WHERE ls.Livro_Codl = l.Codl
                                ) AS Subjects
                            FROM 
                                Livro l
                            GROUP BY	
                                l.Codl, l.Titulo, l.Edicao, l.AnoPublicacao;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vw_Detailed_Books");
        }
    }
}
