# Canducci HubDev

[![Version](https://img.shields.io/nuget/v/Canducci.HubDev.svg?style=plastic&label=version)](https://www.nuget.org/packages/Canducci.HubDev/)
[![NuGet](https://img.shields.io/nuget/dt/Canducci.HubDev.svg)](https://www.nuget.org/packages/Canducci.HubDev/) [![NuGet Packages](https://github.com/fulviocanducci/Canducci.HubDev/actions/workflows/pack.yml/badge.svg)](https://github.com/fulviocanducci/Canducci.HubDev/actions/workflows/pack.yml)

##### _Pacote .NET para integraçao com a API do site:_ `https://www.hubdodesenvolvedor.com.br`

#### Instalação do Pacote

```bash
dotnet add package Canducci.HubDev
```

#### Utilização do Pacote

```csharp
// Substitua pelo seu token de autenticão"
string token = "seu token aqui";
HubDev hubDev = new HubDev(token);
```

#### 1. Para utilizar `ZipSearch` ou _Busca de Cep_, pode fazer o seguinte:

```csharp
ZipSearch zipSearch = new ZipSearch(hubDev);
// Substitua pelo CEP desejado
// Sem async
ZipResponse result = zipSearch.Get("01001000");
// Com async
ZipResponse result = await zipSearch.GetAsync("01001000");
```

#### Resposta: `ZipResponse`

```csharp
bool Status //status da requisição
string ReturnMessage //Mensagem de retorno
int Consumed //Quantidade de requisições consumidas
ZipResponse Result //Resultado da busca de CEP
```

#### Explicando `ZipResponse`:

```csharp
// cep
string Zip
// logradouro
string Street
// complemento
string Complement
// bairro
string Neighborhood
// localidade
string City
// uf
string State
// unidade
string Unit
// ibge
string IbgeCode
// gia
string GiaCode
```

---

#### 2. Para utilizar `CpfSearch` ou _Busca de Cpf_, pode fazer o seguinte:

```csharp
CpfSearch cpfSearch = new CpfSearch(hubDev);
// Substitua pelo Cpf desejado e Data de Nascimento
// Sem async
CpfResponse result = cpfSearch.Get("12345678900", new DateTime(1990, 1, 1));
// Com async
CpfResponse result = await cpfSearch.GetAsync("12345678900", new DateTime(1990, 1, 1));
```

#### Resposta: `CpfResponse`

```csharp
bool Status //status da requisição
string ReturnMessage //Mensagem de retorno
int Consumed //Quantidade de requisições consumidas
CpfResponse Result //Resultado da busca de CPF
```

#### Explicando `CpfResponse`:

```csharp
// numero_de_cpf
string CpfNumber
// nome_da_pf
string FullName
// data_nascimento
string DateOfBirth
// situacao_cadastral
string RegistrationStatus
// data_inscricao
string RegistrationDate
// digito_verificador
string CheckDigit
// comprovante_emitido
string ProofCode
// comprovante_emitido_data
string ProofTimestamp
```

---

#### 3. Para utilizar `CnpjSearch` ou _Busca de Cnpj_, pode fazer o seguinte:

```csharp
CnpjSearch cnpjSearch = new CnpjSearch(hubDev);
// Substitua pelo Cnpj desejado e true/false para incluir ou não I.E.
// Sem async
CnpjResponse result = cnpjSearch.Get("00776574000156", true);
// Com async
CnpjResponse result = await cnpjSearch.GetAsync("00776574000156", true);
```

#### Resposta: `CnpjResponse`

```csharp
bool Status //status da requisição
string ReturnMessage //Mensagem de retorno
int Consumed //Quantidade de requisições consumidas
CnpjResponse Result //Resultado da busca de CNPJ
```

#### Explicando `CnpjResponse`:

```csharp
// numero_de_inscricao
string RegistrationNumber
// tipo
string Type
// abertura
string OpeningDate
// nome
string LegalName
// fantasia
string TradeName
// porte
string CompanySize
// atividade_principal
ActivityItem MainActivity
// atividades_secundarias
List<ActivityItem> SecondaryActivities = new List<ActivityItem>()
// natureza_juridica
string LegalNature
// logradouro
string Street
// numero
string Number
// complemento
string Complement
// cep
string PostalCode
// bairro
string Neighborhood
// municipio
string City
// uf
string State
// email
string Email
// telefone
string Phone
// entidade_federativo_responsavel
string FederalEntityResponsible
// situacao
string Status
// dt_situacao_cadastral
string RegistrationStatusDate
// motivo_situacao_cadastral
string RegistrationStatusReason
// situacao_especial
string SpecialStatus
// data_situacao_especial
string SpecialStatusDate
// capital_social
string ShareCapital
// quadro_socios
List<string> Partners = new List<string>()
// quadro_de_socios
List<PartnerDetailItem> PartnerDetails = new List<PartnerDetailItem>()
// inscricoes_estaduais
StateRegistrationItem StateRegistrations
```

#### 4. Para utilizar `BalanceSearch` ou _Busca de Saldo do sua Conta__, pode fazer o seguinte:

```csharp
BalanceSearch balanceSearch = new BalanceSearch(hubDev);
// Sem async
BalanceResponse result = balanceSearch.Get();
// Com async
BalanceResponse result = await balanceSearch.GetAsync();
```
#### Resposta: `BalanceResponse`

```csharp
bool Status //status da requisição
string ReturnMessage //Mensagem de retorno
int Consumed //Quantidade de requisições consumidas
BalanceResponse Result //Resultado da busca do saldo
```
#### Explicando `BalanceResponse`:
```csharp
// servidor_exclusivo
string ExclusiveServer
// token
string Token
// id
string Id
// saldo R$ 0,00
string Saldo
// status
string Ativo 
```



---

#### 5. Para utilizar `CpfPlusSearch` ou _Busca completa de Cpf_, pode fazer o seguinte:

```csharp
CpfPlusSearch cpfPlusSearch = new CpfPlusSearch(hubDev);
// Substitua pelo Cpf desejado
// Sem async
CpfPlusResponse result = cpfPlusSearch.Get("12345678900");
// Com async
CpfPlusResponse result = await cpfPlusSearch.GetAsync("12345678900");
```

#### Resposta: `CpfPlusResponse`

```csharp
bool Status //status da requisição
string ReturnMessage //Mensagem de retorno
int Consumed //Quantidade de requisições consumidas
CpfPlusResponse Result //Resultado da busca de CPF
```

#### Explicando `CpfPlusResponse`:

```csharp
// codigoPessoa
string PersonCode;
// nomeCompleto
string FullName;
// genero
string Gender;
// dataDeNascimento
DateTime? BirthDate;
// documento
string Document;
// nomeDaMae
string MothersName;
// anos
int Age;
// zodiaco
string Zodiac;
// listaTelefones
List<PhoneItem> PhoneList;
// listaEnderecos
List<AddressItem> AddressList;
// listaEmails
List<EmailItem> EmailList;
// salarioEstimado
string EstimatedSalary;
// statusCadastral
string RegistrationStatus;
// dataStatusCadastral
DateTime? RegistrationStatusDate;
// lastUpdate
DateTime? LastUpdate;
```