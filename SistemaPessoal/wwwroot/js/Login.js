﻿

$(document).ready(function () {
    // função que irar comando o tempo que as mensagem de erro e sucesso apareceram para o usuario apois as alterações nas informações no banco de dados.
    setTimeout(function () { // resumindo, executa uma função depois de uma quantidade de tempo.
        $(#alerta).fadeOut("slow", function () { // função que ele ira executar.
            $(this).alerta('close');
        })
    }, 5000)
});