# HubDev

### Instalação do Pacote
```bash
dotnet add package Canducci.HubDev --version 1.0.1
```

### Utilização do Pacote

```csharp
string token = "seu_token_aqui"; // Substitua pelo seu token de autenticação"
HubDev hubDev = new HubDev(token);
```

### Para utilizar ZipSearch ou Busca de Cep, você pode fazer o seguinte:

```csharp
ZipSearch zipSearch = new ZipSearch(hubDev);
ZipResponse result = await zipSearch.GetAsync("01001000"); // Substitua pelo CEP desejado
```
### Resposta: ZipResponse

```csharp
bool Status //status da requisição
string ReturnMessage //Mensagem de retorno
int Consumed //Quantidade de requisições consumidas
ZipResponse Result //Resultado da busca de CEP
```
