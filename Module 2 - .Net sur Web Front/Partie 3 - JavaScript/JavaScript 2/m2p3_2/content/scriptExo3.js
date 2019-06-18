//Evenement directement sur le document, lorsque je reléve la pression d'une touche du clavier
document.addEventListener("keyup", function () {
    //J'affiche la valeur de l'élément qui posséde l'Id lastname
    alert(document.getElementById('lastname').value);
});

