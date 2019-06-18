//Je stocke l'élément qui posséde l'id lastname
var lastNameInput = document.getElementById("lastname");
//J'applique sur mon élément un événement blur (lorsque je perd le focus)
lastNameInput.addEventListener("blur", function () {
    //On affiche un message différent en fonction se la valuer de l'input
    if (document.getElementById("lastname").value == '') {
        alert("Vous n'avez rien écrit vous auriez pu participer :(");
    } else {
        alert("Merci de votre participation :)");
    }
});
