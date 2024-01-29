# Kabum Ofertas Diárias 

Este é um programa simples desenvolvido em C# que realiza as seguintes tarefas:

- Acessa o site da Kabum para extrair as ofertas do dia.
- Compila as informações das ofertas encontradas.
- Envia um e-mail contendo as ofertas para um destinatário específico.

### Pré-requisitos

- Certifique-se de ter o .NET Core SDK instalado na sua máquina.
- Um navegador Google Chrome instalado, pois o programa utiliza o WebDriver do Chrome.
- É necessário ter uma conta de e-mail do Gmail para enviar os e-mails.

### Configuração

1. Clone ou faça o download deste repositório.
2. Instale as dependências do projeto utilizando o NuGet Package Manager.
3. Crie um arquivo `.env` na raiz do projeto com as seguintes variáveis de ambiente:

- REMETENTE=sua_conta@gmail.com
- SENHA=sua_senha
- DESTINATARIO=email_destinatario@provedor.com


### Execução

1. Abra o terminal na pasta do projeto.
2. Execute `dotnet run` para iniciar a execução do programa.
3. O programa acessará o site da Kabum, extrairá as ofertas do dia, compilará as informações e enviará um e-mail para o destinatário especificado.


### Observações

- Certifique-se de que suas credenciais de e-mail estejam corretas no arquivo `.env`.
- Caso deseje alterar o intervalo de tempo para esperar a página carregar (`System.Threading.Thread.Sleep(5000)`), você pode modificar esse valor no código-fonte.
- Em caso de erros durante a execução, verifique a saída no console para diagnóstico.
- A aplicação ainda está em desenvolvimento e será modificada para se enquadrar nos principios do SOLID.
  
### Avisos Legais

Este programa foi desenvolvido apenas para fins educacionais e de demonstração. O uso responsável e ético é encorajado.
