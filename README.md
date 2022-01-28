# spacex-api

## Objetivo

Esta API tem como objetivo disponibilizar informações sobre lançamento de foguetes da SpaceX conforme rotas documentadas no Swagger da solução:

`/next-launch`: lista o próximo lançamento agendado

`/latest-launch`: lista o último lançamento ocorrido

`/upcoming-launches`: lista os próximos lançamentos agendados

`/past-launches`: lista os lançamentos passados

Para fins de documentação da API, deixei o Swagger ativado mesmo fora do ambiente de desenvolvimento na raíz do site.

O código publicado na branch `main` está disponível [neste servidor](https://my-spacex-api.azurewebsites.net) (conta pessoal do Azure)

## Projeto

O projeto foi desenvolvido em ASP.NET 6 (web-api). As requisições fora todas abstraídas para o serviço `ApiRequestService`, que é injetado no controller via DI, onde o controller orquestra as requisições de acordo com a rota solicitada.