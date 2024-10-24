

$(document).ready(function () {
    // função que irar comando o tempo que as mensagem de erro e sucesso apareceram para o usuario apois as alterações nas informações no banco de dados.
    setTimeout(function () { // resumindo, executa uma função depois de uma quantidade de tempo.
        $(".alerta").fadeOut("slow", function () { // função que ele ira executar.
            $(this).alerta('close');
        })
    }, 3000)

    $(document).ready(function () {
        setTimeout(function () {
            $('#mensagem-erro').fadeOut('slow'); // Faz a mensagem desaparecer suavemente
        }, 3000); // 5000 ms = 5 segundos
    });

    $(document).ready(function () {
        setTimeout(function () {
            $('#mensagem-alert').fadeOut('slow'); // Faz a mensagem desaparecer suavemente
        }, 3000); // 5000 ms = 5 segundos
    });

});

function togglePassword(fieldId, iconId) {
    const passwordField = document.getElementById(fieldId);
    const eyeIcon = document.getElementById(iconId);

    if (passwordField.type === 'password') {
        passwordField.type = 'text';
        eyeIcon.innerHTML = '👁️'; // Muda o ícone para um ícone de "esconder"
    } else {
        passwordField.type = 'password';
        eyeIcon.innerHTML = '🙈'; // Muda o ícone para um ícone de "mostrar"
    }
}

