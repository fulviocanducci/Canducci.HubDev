# HubDev

### Instala��o do Pacote
```bash
dotnet add package Canducci.HubDev --version 1.0.1
```

### Utiliza��o do Pacote

```csharp
string token = "seu_token_aqui"; // Substitua pelo seu token de autentica��o"
HubDev hubDev = new HubDev(token);
```

### Para utilizar ZipSearch ou Busca de Cep, voc� pode fazer o seguinte:

```csharp
ZipSearch zipSearch = new ZipSearch(hubDev);
ZipResponse result = await zipSearch.GetAsync("01001000"); // Substitua pelo CEP desejado
```
### Resposta: ZipResponse

```csharp
bool Status //status da requisi��o
string ReturnMessage //Mensagem de retorno
int Consumed //Quantidade de requisi��es consumidas
ZipResponse Result //Resultado da busca de CEP
```
