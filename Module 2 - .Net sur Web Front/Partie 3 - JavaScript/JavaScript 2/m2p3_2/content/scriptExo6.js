//function changePicture(idMyElement) {
//    if (document.getElementById(idMyElement).src.substr(-6,2) == '_2') {
//        document.getElementById(idMyElement).src = 'images/' + idMyElement + '.jpg';
//    } else {
//        document.getElementById(idMyElement).src = 'images/' + idMyElement + '_2.jpg';
//    }
//}

//Je d�clare ma fonction changePictureMouseOver avec le param�tre idMyElement
function changePictureMouseOver(idMyElement) {
    //Je change la src de l'�l�ment poss�dant l'id sotcker dans le param�tre
    document.getElementById(idMyElement).src = 'images/' + idMyElement + '_2.jpg';
}
function changePictureMouseOut(idMyElement) {
    document.getElementById(idMyElement).src = 'images/' + idMyElement + '.jpg';
}