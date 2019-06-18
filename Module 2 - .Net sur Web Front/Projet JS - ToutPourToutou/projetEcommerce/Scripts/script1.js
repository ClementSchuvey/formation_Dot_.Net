$(document).ready(function () {
    // Fonction pour ajouter un produit dans le panier
    $('.addProduct').click(function () {
        // Option pour la notification
        toastr.options.progressBar = true;
        //Déclaration des variables
        var createProduct = false;
        // Déclaration des variables avec des valeurs précis
        var product = $(this).attr('id');
        var array = $(this).attr('array');
        // On fait une condition pour savoir lequel des tableaux faut qu'il utilise
        if (array == 'food') {
            var arrJSON = typeof food != 'object' ? JSON.parse(food) : food;
        } else if (array == 'heal') {
            var arrJSON = typeof heal != 'object' ? JSON.parse(heal) : heal;
        } else if (array == 'accessory') {
            var arrJSON = typeof accessory != 'object' ? JSON.parse(accessory) : accessory;
        }
        // Parcours le tableau de la class Product afin de connaître si l'article est déjà présent dans le panier
        $.each($('.product'), function (index, element) {
            // Si id de la ligne du tableau est égale référence du produit
            if (element.id == product) {
                // Récupérer la quantité actuelle avec les enfants de l'élément
                var quantity = element.children[3].children[1].innerHTML;
                // Incrémentation de la variable quantity
                quantity++;
                // Nouvelle affichage avec la nouvelle quantite
                element.children[3].children[1].innerHTML = quantity;
                // On met la création du produit à vrai
                createProduct = true
                // Affichage de la notification de la quantite
                toastr.success('Quantite du produit : ' + quantity);
            }
        });
        // Parcours le tableau de la catégorie choisie 
        $.each(arrJSON, function (index, element) {
            // Si création de objet n'est pas égal vrai
            if (createProduct !== true) {
                // Récupération du produit choisi et ajout du produit dans le panier en html
                if (product == element.ref) {
                    $('#addProductTable').append('<tr class="product" id="' + element.ref + '">' +
                        '<td>' + element.ref + '</td>' +
                        '<td><img class="imgProduct" alt="Image ' + element.title + '" title="Image de produit" src="' + element.img + '" /></td>' +
                        '<td>' + element.title + '</td>' +
                        '<td> <input type="button" class="deleteQuantity" value="-" /> <span class="quantity">1</span> <input type="button" class="addQuantity" value="+" /></td>' +
                        '<td>' + element.price + '</td>' +
                        '<td><a href="#" class="supprProduct"><i class="fas fa-times"></i></a></td>' +
                        '</tr>'
                    );
                    // Notification de succès lors de l'ajout du produit dans le panier
                    toastr.success('Ajout du produit <i>' + element.title + '</i> dans le panier');
                }
            }
        });
        // Appel les fonctions totalPrice pour le total du prix et totalProduct pour le total des produits présent dans le panier
        totalPrice();
        totalProduct();
    });
    // Fonction de la suppression de produit dans le panier
    $('#productCard').on('click', '.supprProduct', function () {
        var balise = $(this).parent().parent();
        balise.fadeOut("slow");
        // Récupérer la balise actuelle lors du clique ensuite on récupérer son parent ainsi de suite jusqu'au tr afin de supprimer la ligne entière
        setTimeout(function () {
            balise.remove();
            // Condition afin de savoir s'il y a des produit dans le panier 
            if ($('#addProductTable').children().length == 0) {
                // Met le prix total à 0
                $('#totalPriceCommand').text('0€');
            } else {
                totalPrice();
            }
            totalProduct();
        }, 1000);
    });
    // Fonction pour la décrementation de la quantité
    $('#productCard').on('click', '.deleteQuantity', function () {
        // Récupération de la quantité (siblings = frére)
        var modifyQuantity = $(this).siblings('span').text();
        // Décrémentation de la quantité
        modifyQuantity--;
        // Si la quantité est inférieur ou égal à 0
        if (modifyQuantity <= 0) {
            $(this).parent().parent().remove();
            if ($('#addProductTable').children().length == 0) {
                $('#totalPriceCommand').text('0€');
            }
            totalProduct();
        } else {
            $(this).siblings('span').text(modifyQuantity);
        }
        totalPrice();
    });
    // Fonction pour la incrémentation de la quantité
    $('#productCard').on('click', '.addQuantity', function () {
        var modifyQuantity = $(this).siblings('span').text();
        modifyQuantity++;
        $(this).siblings('span').text(modifyQuantity);
        totalPrice();
    });
    // Cache les sections de base
    $('.foodCategory').hide();
    $('.healCategory').hide();
    $('.accessoryCategory').hide();
    // Affichage de la section home
    $('#btnHome').click(function () {
        $('.home').show(1000);
        $('.foodCategory').hide();
        $('.healCategory').hide();
        $('.accessoryCategory').hide();
    });
    // Affichage de la section foodCategory
    $('#btnFood').click(function () {
        $('.home').hide();
        $('.foodCategory').show(1000);
        $('.healCategory').hide();
        $('.accessoryCategory').hide();
    });
    // Affichage de la section healCategory
    $('#btnHeal').click(function () {
        $('.home').hide();
        $('.foodCategory').hide();
        $('.healCategory').show(1000);
        $('.accessoryCategory').hide();
    });
    // Affichage de la section accessoryCategory
    $('#btnAccessory').click(function () {
        $('.home').hide();
        $('.foodCategory').hide();
        $('.healCategory').hide();
        $('.accessoryCategory').show(1000);
    });
    // Fonction qui calcule le prix total
    function totalPrice() {
        var totalPrice = 0;
        $.each($('.product'), function (index, element) {
            console.log(element);
            var quantityElement = element.children[3].children[1].innerHTML;
            var priceElement = element.children[4].innerHTML;
            priceElement = priceElement.split('€');
            priceElement = priceElement[0] + '.' + priceElement[1];
            totalPrice = totalPrice + quantityElement * priceElement;
        });
        totalPrice = totalPrice.toFixed(2);
        totalPrice = totalPrice.replace('.', '€');
        $('#totalPriceCommand').text(totalPrice);
    };
    // Fonction qui calcule les produits présent dans le panier
    function totalProduct() {
        var totalProduct = 0;
        $.each($('.product'), function (index, element) {
            totalProduct++;
        });
        $('#countProduct').text(totalProduct);
    };
    $('.buttonColor2').click(function () {
        swal({
            title: "Voulez-vous valider votre panier?",
            icon: "warning",
            buttons: {
                cancel: "Non",
                catch: {
                    text: "Oui",
                    value: "Oui",
                },
            },
            dangerMode: true,
        })
            .then((value) => {
                switch (value) {

                    case "non":
                        swal("Continuez votre shopping !");
                        break;

                    case "Oui":
                        swal("Valider !", "Votre panier est confirmé, procéder au mode de paiement", "success");
                        $('.product').remove();
                        $('#totalPriceCommand').text('0€');
                        break;
                    default:
                        swal("Continuez votre shopping !");
                }
            });
});
});