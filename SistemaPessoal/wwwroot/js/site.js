

// codigo refrente ao uso dos filtros na pagina
$(document).ready(function () {
    // o que tiver dentro a function, vai ser rodado dentro da pagina junto ao JS.

    $('#Despesas').DataTable({ // codogio onde é possivel está mudando a linguagem dos filtros ja estilizados.
        language: {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "Mostrando _START_ registro de _END_ em um totla de _TOTAL_ entradas",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ entradas",
            "loadingRecords": "Loading...",
            "processing": "",
            "search": "Procurar:",
            "zeroRecords": "No matching records found",
            "paginate": {
                "first": "Primeiro",
                "last": "Ultimo",
                "next": "Proximo",
                "previous": "Anterior"
            },
            "aria": {
                "orderable": "Order by this column",
                "orderableReverse": "Reverse order this column"
            }
        }
    });


    // função que irar comando o tempo que as mensagem de erro e sucesso apareceram para o usuario apois as alterações nas informações no banco de dados.
    setTimeout(function () { // resumindo, executa uma função depois de uma quantidade de tempo.
        $(".alert").fadeOut("slow", function () { // função que ele ira executar.
            $(this).alert('close');
        })
    }, 3000)

});

function formatarData(input) {
    let valor = input.value;

    // Remove tudo que não for número
    valor = valor.replace(/\D/g, "");

    // Coloca a barra entre o dia, mês e ano
    if (valor.length >= 5) {
        input.value = valor.substring(0, 2) + '/' + valor.substring(2, 4) + '/' + valor.substring(4, 8);
    } else if (valor.length >= 3) {
        input.value = valor.substring(0, 2) + '/' + valor.substring(2, 4);
    } else if (valor.length >= 1) {
        input.value = valor.substring(0, 2);
    }
}

function redirecionar(opcaoSelecionada) {
    if (opcaoSelecionada) {
        window.location.href = "/Config/" + opcaoSelecionada;
    }
}

