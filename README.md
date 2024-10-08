﻿# Split Query
Sabe quando você faz uma consulta envolvendo duas ou mais tabelas, e um registro da primeira tabela está relacionado a N registros da segunda? Isso faz com que o resultado tenha N linhas, onde uma coluna repete o mesmo valor várias vezes. Esse fenômeno é chamado de 'Explosão Cartesiana', e pode causar alto consumo de memória e processamento.

Li vários Posts falando para resolver este problema utilizando consultas separadas (Split Query), mas raramente encontrava algum que trazia algum Benchmark. Portanto, para sanar essa dúvida do quanto é melhor, resolvi trazer resultados de alguns testes feitos por mim.

Abaixo temos três testes realizados com quantidades diferentes de dados retornados, isso mostra que dependendo da quantidade de dados o uso do Split Query não é viável. Além destes três cenários no final para consultas paginadas que me surpreendeu.

Para este teste foi utilizado o ORM Entity Framework Core com a propriedade AsSplitQuery, a qual faz este processo de Split.

Resultados de uma consulta onde o número total de registros contidos nas tabelas eram de 12 registros:

| Method | Mean | Error | StdDev | Median | Gen0 | Allocated |
| --- | --- | --- | --- | --- | --- | --- |
| QueryWithSplit | 500.3 us | 28.22 us | 83.20 us | 485.0 us | 5.8594 | 36.22 KB |
| QueryWithoutSplit | 215.1 us | 4.17 us | 8.88 us | 211.7 us | 2.9297 | 22.32 KB |

| Method | Mean | Error | StdDev | Gen0 | Allocated |
| --- | --- | --- | --- | --- | --- |
| QueryWithSplit | 424.9 us | 8.49 us | 15.32 us | 5.8594 | 36.07 KB |
| QueryWithoutSplit | 206.1 us | 2.35 us | 1.84 us | 2.9297 | 22.32 KB |


Resultados de uma consulta onde o número total de registros contidos nas tabelas eram de 30 registros:

| Method | Mean | Error | StdDev | Gen0 | Allocated |
| --- | --- | --- | --- | --- | --- |
| QueryWithSplit | 446.1 us | 7.69 us | 7.89 us | 7.8125 | 55.21 KB |
| QueryWithoutSplit | 429.7 us | 8.59 us | 19.56 us | 5.8594 | 39.31 KB |

| Method | Mean | Error | StdDev | Gen0 | Allocated |
| --- | --- | --- | --- | --- | --- |
| QueryWithSplit | 498.8 us | 9.67 us | 12.91 us | 8.7891 | 55.21 KB |
| QueryWithoutSplit | 527.3 us | 18.61 us | 54.88 us | 5.8594 | 39.32 KB |


Resultados de uma consulta onde o número total de registros contidos nas tabelas eram de 90 registros:

| Method | Mean | Error | StdDev | Gen0 | Allocated |
| --- | --- | --- | --- | --- | --- |
| QueryWithSplit | 1.160 ms | 0.0199 ms | 0.0425 ms | 23.4375 | 150.98 KB |
| QueryWithoutSplit | 1.890 ms | 0.0243 ms | 0.0215 ms | 15.6250 | 119.11 KB |

| Method | Mean | Error | StdDev | Gen0 | Allocated |
| --- | --- | --- | --- | --- | --- |
| QueryWithSplit | 1.092 ms | 0.0217 ms | 0.0386 ms | 23.4375 | 150.98 KB |
| QueryWithoutSplit | 1.781 ms | 0.0155 ms | 0.0138 ms | 15.6250 | 118.98 KB |


Mas se com poucos registros é inviável utilizar Split Query, quando uma consulta é paginada e traz poucos dados, exemplo 10, ainda vale à pena? Os resultados falam por sí só.

| Method | Mean | Error | StdDev | Gen0 | Allocated |
| --- | --- | --- | --- | --- | --- |
| QueryWithSplit | 493.5 us | 9.47 us | 10.53 us | 11.7188 | 78.48 KB |
| QueryWithoutSplit | 1,164.1 us | 8.54 us | 7.57 us | 7.8125 | 53.59 KB |

| Method | Mean | Error | StdDev | Gen0 | Allocated |
| --- | --- | --- | --- | --- | --- |
| QueryWithSplit | 494.6 us | 4.68 us | 7.95 us | 11.7188 | 78.42 KB |
| QueryWithoutSplit | 1,210.2 us | 14.25 us | 12.63 us | 7.8125 | 53.71 KB |
