//Je stoke mon élément avec l'id Image1
var picture = document.getElementById('image1');

//Evenement lorsque je passe le curseur sur l'image
picture.addEventListener("mouseover", function () {
    //Je change le src de l'élément possédant l'id image1
    document.getElementById('image1').src = 'images/image1_2.jpg'
});
//Evenement lorsque je sors le curseur sur l'image
picture.addEventListener("mouseout", function () {
    //Je change le src de l'élément possédant l'id image1
    document.getElementById('image1').src = 'images/image1.jpg'
});