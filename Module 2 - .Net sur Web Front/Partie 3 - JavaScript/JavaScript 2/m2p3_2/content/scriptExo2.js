//Je stocke l'�l�ment qui poss�de l'id lastname
var lastNameInput = document.getElementById("lastname");
//J'applique sur mon �l�ment un �v�nement blur (lorsque je perd le focus)
lastNameInput.addEventListener("blur", function () {
    //On affiche un message diff�rent en fonction se la valuer de l'input
    if (document.getElementById("lastname").value == '') {
        alert("Vous n'avez rien �crit vous auriez pu participer :(");
    } else {
        alert("Merci de votre participation :)");
    }
});
