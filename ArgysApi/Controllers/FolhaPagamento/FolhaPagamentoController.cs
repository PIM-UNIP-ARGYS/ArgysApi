using ArgysApi.Data;
using ArgysApi.Models.FolhaPagamento;
using ArgysApi.Models.Pessoas;
using ArgysApi.Models.Vinculos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArgysApi.Controllers.FolhaPagamento
{
    [Route("api/folha_pagamento")]
    [ApiController]
    public class FolhaPagamentoController : ControllerBase
    {
        private readonly ArgysApiContext _context;

        public FolhaPagamentoController(ArgysApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GenerateFp([FromQuery] string referencia)
        {

            var vinculo = await _context.Vinculo.ToListAsync();
            var pessoa = await _context.Pessoa.ToListAsync();
            var vinculoCargo = await _context.VinculoCargo.ToListAsync();
            var cargo = await _context.Cargo.ToListAsync();
            var cbo = await _context.Cbo.ToListAsync();
            var salario = await _context.VinculoSalario.ToListAsync();

            await this.GeneratePdf(vinculo, pessoa, vinculoCargo, cargo, cbo, salario, referencia);
            return Ok();
        }


        [HttpGet("historico")]
        public async Task<ActionResult<IEnumerable<Fp>>> GenerateFp()
        {
            var fps = await _context.Fp.ToListAsync();
            return fps;
        }

        private async Task GeneratePdf(List<Vinculo> vinculos, List<Pessoa> pessoas, List<VinculoCargo> vinculoCargos,
            List<Cargo> cargos, List<Cbo> cbos, List<VinculoSalario> salarios, string referencia)
        {
            foreach (var vinculo in vinculos) {
                byte[] pdfBytes;

                string filePath = $"FP-{vinculo.Matricula}-{referencia}.pdf";

                using (MemoryStream ms = new MemoryStream()) {
                    var pessoa = pessoas.Where(x => x.Id == vinculo.PessoaId).First();
                    var vinculoCargo = vinculoCargos.Where(x => x.VinculoId == vinculo.Id).First();
                    var cargo = cargos.Where(x => x.Id == vinculoCargo.CargoId).First();
                    var cbo = cbos.Where(x => x.Id == vinculo.CboId).First();
                    var salario = salarios.Where(x => x.VinculoId == vinculo.Id).First();


                    var salarioDesconto = salario.ValorSalario.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    var descansoRem = ((salario.ValorSalario / salario.NumeroHorasMensais) * 8).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    var inss = ((salario.ValorSalario / 100) * new decimal(11.68)).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));

                    var totalProv = salario.ValorSalario + Math.Round(((salario.ValorSalario / salario.NumeroHorasMensais) * 8), 2);
                    var totalDesc = ((salario.ValorSalario / 100) * new decimal(11.68)) + ((salario.ValorSalario / 100) * new decimal(27.50)) + new decimal(300.00);
                    var total = (totalProv - totalDesc).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    var fgts = Math.Round(((totalProv / 100) * new decimal(11.68)), 2);
                    var irffBase = totalProv - fgts;
                    var irrf = Math.Round(((irffBase / 100) * new decimal(27.50)), 2).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    totalProv.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    totalDesc.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    fgts.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));

                    Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
                    document.Open();

                    Paragraph title = new Paragraph("Folha de Pagamento");
                    title.Alignment = Element.ALIGN_CENTER;
                    title.Font.Size = 18;
                    document.Add(title);

                    Paragraph referenciaParagraph = new Paragraph($"Referente ao Mês/Ano: {referencia}");
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(referenciaParagraph);

                    document.Add(new Paragraph(" "));

                    PdfPTable tInfo = new PdfPTable(4);
                    tInfo.WidthPercentage = 100;
                    tInfo.HeaderRows = 1;
                    tInfo.SetWidths(new[] { 20, 80, 20, 20 });

                    tInfo.AddCell(new PdfPCell(new Phrase("CÓDIGO")));
                    tInfo.AddCell(new PdfPCell(new Phrase("NOME DO FUNCIONÁRIO")));
                    tInfo.AddCell(new PdfPCell(new Phrase("CBO")));
                    tInfo.AddCell(new PdfPCell(new Phrase("FUNÇÃO")));

                    tInfo.AddCell(new PdfPCell(new Phrase($"{vinculo.Matricula}")));
                    tInfo.AddCell(new PdfPCell(new Phrase($"{pessoa.Nome}")));
                    tInfo.AddCell(new PdfPCell(new Phrase($"{cbo.Descricao}")));
                    tInfo.AddCell(new PdfPCell(new Phrase($"{cargo.Descricao}")));

                    document.Add(tInfo);

                    document.Add(new Paragraph(" "));

                    PdfPTable tDescontos = new PdfPTable(5);
                    tDescontos.WidthPercentage = 100;
                    tDescontos.HeaderRows = 1;
                    tDescontos.SetWidths(new[] { 10, 70, 20, 20, 20 });

                    tDescontos.AddCell(new PdfPCell(new Phrase("Cód")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("Descrição")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("Referência")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("Proventos")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("Descontos")));

                    tDescontos.AddCell(new PdfPCell(new Phrase("")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("SALARIO BASE")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("220:00")));
                    tDescontos.AddCell(new PdfPCell(new Phrase($"{salarioDesconto}")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("")));

                    tDescontos.AddCell(new PdfPCell(new Phrase("")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("HORAS EXTRAS (50%)")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("0")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("0,00")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("")));

                    tDescontos.AddCell(new PdfPCell(new Phrase("")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("DESCANSO SEMANAL REMUNERADO")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("")));
                    tDescontos.AddCell(new PdfPCell(new Phrase($"{descansoRem}")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("")));

                    tDescontos.AddCell(new PdfPCell(new Phrase("")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("PLANO DE SAÚDE")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("300,00")));

                    tDescontos.AddCell(new PdfPCell(new Phrase("")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("INSS")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("11,68%")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("")));
                    tDescontos.AddCell(new PdfPCell(new Phrase($"{inss}")));

                    tDescontos.AddCell(new PdfPCell(new Phrase("")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("IRRF")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("27,50%")));
                    tDescontos.AddCell(new PdfPCell(new Phrase("")));
                    tDescontos.AddCell(new PdfPCell(new Phrase($"{irrf}")));

                    document.Add(tDescontos);

                    document.Add(new Paragraph(" "));

                    PdfPTable tTotal = new PdfPTable(2);
                    tTotal.WidthPercentage = 50;
                    tTotal.HeaderRows = 1;
                    tTotal.HorizontalAlignment = Element.ALIGN_RIGHT;

                    tTotal.AddCell(new PdfPCell(new Phrase("Total dos Vencimentos")));
                    tTotal.AddCell(new PdfPCell(new Phrase("Total dos Descontos")));


                    tTotal.AddCell(new PdfPCell(new Phrase($"{totalProv}")));
                    tTotal.AddCell(new PdfPCell(new Phrase($"{totalDesc}")));

                    tTotal.AddCell(new PdfPCell(new Phrase("A receber")));
                    tTotal.AddCell(new PdfPCell(new Phrase($"{total}")));

                    document.Add(tTotal);

                    document.Add(new Paragraph(" "));

                    PdfPTable tFooter = new PdfPTable(6);
                    tFooter.WidthPercentage = 100;
                    tFooter.HeaderRows = 0;

                    tFooter.AddCell(new PdfPCell(new Phrase("Sálario Base")));
                    tFooter.AddCell(new PdfPCell(new Phrase("Base Cálc. INSS")));
                    tFooter.AddCell(new PdfPCell(new Phrase("Base Cálc. FGTS")));
                    tFooter.AddCell(new PdfPCell(new Phrase("FGTS do Mês")));
                    tFooter.AddCell(new PdfPCell(new Phrase("Base Cálc. IRRF")));
                    tFooter.AddCell(new PdfPCell(new Phrase("Faixa IRRF")));

                    tFooter.AddCell(new PdfPCell(new Phrase($"{salarioDesconto}")));
                    tFooter.AddCell(new PdfPCell(new Phrase($"{totalProv}")));
                    tFooter.AddCell(new PdfPCell(new Phrase($"{totalProv}")));
                    tFooter.AddCell(new PdfPCell(new Phrase($"{fgts}")));
                    tFooter.AddCell(new PdfPCell(new Phrase($"{irffBase}")));
                    tFooter.AddCell(new PdfPCell(new Phrase("5")));

                    document.Add(tFooter);

                    document.Close();
                    pdfBytes = ms.ToArray();
                }

                await this.SavePdfToDatabase(vinculo.Id, pdfBytes, filePath);
            }
        }

        private async Task SavePdfToDatabase(long vinculoId, byte[] pdfBytes, string fileName)
        {
            Fp pdfModel = new Fp
            {
                Uuid = Guid.NewGuid().ToString(),
                VinculoId = vinculoId,
                FolhaPagamento = pdfBytes,
                NomeArquivo = fileName
            };

            _context.Fp.Add(pdfModel);
            await _context.SaveChangesAsync();
        }
    }
}
