## QwenClient

É um Form com compontente Web para acessar a página da IA [Qwen](https://qwenlm.ai/) de forma prática e rápida.

Fiz dois programas para trabalharem juntos, sendo eles o QwenAgent e o QwenClient.

<img src=".\img\01.png" />

O QwenClient é responsável por acessar o site e mostrar a interface no centro da tela de forma prática, enquanto o QwenAgent é responsável por chamar o QwenClient com o comando `Alt + C` do teclado.



#### Como funciona?

Após executar o QwenAgent ele irá esperar constantemente em background pelo comando do teclado responsável por chamar o QwenClient. Utilizando uma biblioteca da API do Windows `user32.dll`

<img src=".\img\02.png" />

**QwenAgent usa poucos recursos do computador e é quase irrelevante, porém é completamente opcional. Você pode abrir o QwenClient manualmente sem problemas.**

Após pressionar as teclas `Alt + C` seu assistente de IA irá abrir pronto para utilização

<img src=".\img\03.png" style="zoom: 55%;" />





## Mudando as teclas de atalho para chamar o QwenClient

Infelizmente ainda não implementei isso como recurso no QwenAgent ainda, então você vai ter que recompilar o QwenClient com as mudanças que quiser.

Pra fazer isso simplesmente mude os valores dessas duas variáveis:

<img src=".\img\04.png" />



Você deve colocar o valor em hexadecimal respectivo das teclas que quer adicionar. Para isso consulte a tabela de [Virtual Key Code](https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes) do Windows e substitua a vontade. 




## QwenAgent iniciando com junto com o Windows

Para iniciar o QwenAgent com o Windows e deixar o QwenClient de prontidão para o uso basta adicionar um atalho do QwenAgent na pasta de inicialização do Windows

Para fazer isso basta executar `shell:startup` no Explorer 

<img src=".\img\05.png" />

Crie um atalho dentro da pasta Inicializar

<img src=".\img\06.png" />

E insira o caminho onde você deixou o executável do QwenAgent

<img src=".\img\07.png" />

E pronto
