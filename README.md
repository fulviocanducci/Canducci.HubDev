# HubDev 
(Pacote .NET para integração com a API do site: https://www.hubdodesenvolvedor.com.br))

#### Instalação do Pacote
```bash
dotnet add package Canducci.HubDev
```

#### Utilização do Pacote
```csharp
// Substitua pelo seu token de autenticação"
string token = "seu_token_aqui"; 
HubDev hubDev = new HubDev(token);
```

#### Para utilizar ZipSearch ou Busca de Cep, você pode fazer o seguinte:
```csharp
ZipSearch zipSearch = new ZipSearch(hubDev);
// Substitua pelo CEP desejado
ZipResponse result = await zipSearch.GetAsync("01001000"); 
```

#### Resposta: ZipResponse
```csharp
bool Status //status da requisição
string ReturnMessage //Mensagem de retorno
int Consumed //Quantidade de requisições consumidas
ZipResponse Result //Resultado da busca de CEP
```

#### Para utilizar CpfSearch ou Busca de Cpf, você pode fazer o seguinte:
```csharp
CpfSearch cpfSearch = new CpfSearch(hubDev);
// Substitua pelo Cpf desejado e Data de Nascimento
CpfResponse result = await cpfSearch.GetAsync("12345678900", new DateTime(1990, 1, 1)); 
```

#### Resposta: CpfResponse
```csharp
bool Status //status da requisição
string ReturnMessage //Mensagem de retorno
int Consumed //Quantidade de requisições consumidas
CpfResponse Result //Resultado da busca de CPF
```

#### Para utilizar CnpjSearch ou Busca de Cnpj, você pode fazer o seguinte:
```csharp
CnpjSearch cnpjSearch = new CnpjSearch(hubDev);
// Substitua pelo Cnpj desejado e true/false para incluir ou não I.E.
CnpjResponse result = await cnpjSearch.GetAsync("00776574000156", true); 
```

#### Resposta: CnpjResponse
```csharp
bool Status //status da requisição
string ReturnMessage //Mensagem de retorno
int Consumed //Quantidade de requisições consumidas
CnpjResponse Result //Resultado da busca de CPF
```