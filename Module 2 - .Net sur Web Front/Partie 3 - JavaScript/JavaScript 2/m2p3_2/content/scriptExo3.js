//Evenement directement sur le document, lorsque je rel�ve la pression d'une touche du clavier
document.addEventListener("keyup", function () {
    //J'affiche la valeur de l'�l�ment qui poss�de l'Id lastname
    alert(document.getElementById('lastname').value);
});

