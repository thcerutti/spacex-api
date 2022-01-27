# spacex-api

## Objetivo

Esta API tem como objetivo disponibilizar informações sobre lançamento de foguetes da SpaceX pelas rotas:

`/next-launch`: lista o próximo lançamento agendado

`/latest-launch`: lista o último lançamento ocorrido

`/upcoming-launches`: lista os próximos lançamentos agendados

`/past-launches`: lista os lançamentos passados

## Projeto

O projeto foi desenvolvido em ASP.NET 6 (web-api), e foi adotada uma abordagem minimalista visto que o objetivo da API é pontual.

As requisições fora todas abstraídas para o serviço `ApiRequestService`, que é injetado no controller via DI, onde o controller orquestra as requisições de acordo com a rota solicitada.