// Déclaration des tableaux des produits disponnibles
var food = '[{"title":"Pedigree Sachets Fraîcheur", "img":"Image/food/food_1.jpg", "desc":"Nourriture pour Chien Adulte aux 4 Saveurs en Sauce, 84 Sachets Repas de 100g","price":"36€55","ref":"001"},' +
    '{"title":"Eukanuba - Croquettes Premium", "img":"Image/food/food_2.jpg", "desc":"Nourriture pour Chiens Adultes Grandes Races - 100% Complète et Equilibrée - Riche en Poulet frais - Sans protéines végétales cachées, OGM, conservateurs ou arôme artificiel - 15kg","price":"63€99","ref":"002"},' +
    '{"title":"Croquette Top Budget", "img":"Image/food/food_3.jpg", "desc":"Nourriture pour Chiens Tout âges - Saveur viande - 4kg","price":"10€00","ref":"003"},' +
    '{"title":"Edgard & Cooper", "img":"Image/food/food_4.jpg", "desc":"Patée pour chien Barquette au Saumon et Truite pour Chien - 150g","price":"1€55","ref":"004"},' +
    '{"title":"Lily\'s Kitchen", "img":"Image/food/food_5.jpg", "desc":"Patée pour chien - Recette Civet de Chevreuil et Faisan pour Chiens - 400g","price":"3€90","ref":"005"},' +
    '{"title":"Royal Canin", "img":"Image/food/food_6.jpg", "desc":"Lait Baby Dog Milk pour Chiot - 2Kg","price":"55€55","ref":"006"}]';

var accessory = '[{"title":"Conteneur à Croquettes", "img":"Image/accessory/accessory_1.jpg", "desc":"Curver 181204 Petlife Conteneur à Croquettes Version Chiens Vert / Blanc / Gris","price":"29€75","ref":"007"},' +
    '{"title":"Distributeur Automatique", "img":"Image/accessory/accessory_2.jpg", "desc":"Distributeur programmable et sécurisé qui est pratique avec son récipient détachable, clipsable et lavable permettant de programmer jusqu\'à 4 repas par jour","price":"119€99","ref":"008"},' +
    '{"title":"Gamelle chien reglable", "img":"Image/accessory/accessory_3.jpg", "desc":"Support double gamelles chien en métal laqué noir, réglable en hauteur et fourni avec 2 gamelles en inox décorées. Pour petit et moyen chien.","price":"16€00","ref":"009"},' +
    '{"title":"Niche pour chien", "img":"Image/accessory/accessory_4.jpg", "desc":"Kerbl - Niche Overview pour Chiens","price":"250€99","ref":"010"},' +
    '{"title":"Peluche Chewbacca", "img":"Image/accessory/accessory_5.jpg", "desc":"Star Wars - Peluche Chewbacca Star Wars pour Chien - 30cm","price":"8€90","ref":"011"},' +
    '{"title":"Gamelle pour chien", "img":"Image/accessory/accessory_6.jpg", "desc":"Bobby - Gamelle Manege noir 10","price":"6€40","ref":"012"}]';

var heal = '[{"title":"Baume protecteur coussinets", "img":"Image/heal/heal_1.jpg", "desc":"Votre chien marche pieds nus toute la journée sur des surfaces abrasives ou irritantes. Ses coussinets sont mis à rude épreuve sur les trottoirs, l\'asphalte chaude, le sel ou la neige.","price":"24€00","ref":"013"},' +
    '{"title":"Shampoing bondi", "img":"Image/heal/heal_2.jpg", "desc":"Laissez-vous emportez par les senteurs piquantes et enivrantes du bush Australien grâce à ce shampoing haut de gamme pour votre animal.","price":"19€00","ref":"014"},' +
    '{"title":"Shampoing réparateur", "img":"Image/heal/heal_3.jpg", "desc":"Cet après-shampoing est formulé à partir d\'ingrédients 100 % naturels obtenus à partir de plantes.","price":"24€00","ref":"015"},' +
    '{"title":"Baume dorée ", "img":"Image/heal/heal_4.jpg", "desc":"Extravagance 1, est un soin d’exception pour le nez et les pattes de votre petit trésor. Une feuille d’or 24 carats flotte sur un lit de beurre de karité bio du Ghana propre à hydrater les truffes et les coussinets les plus exigeants.","price":"86€30","ref":"016"},' +
    '{"title":"Spa beauty", "img":"Image/heal/heal_5.jpg", "desc":"Soin relaxant à l’eau florale de Manuka bio aux vertus apaisante, à l’huile vierge de Coco hydratante et à l’avoine calmant et hydratant.","price":"30€20","ref":"017"},' +
    '{"title":"Spa Concentré Bien-être", "img":"Image/heal/heal_6.jpg", "desc":"Une séance de SPA digne d’un palace. Votre chien va adorer ce soin relaxant à l’eau florale de Manuka bio aux vertus apaisante, à l’huile vierge de Coco hydratante et à l’avoine calmant et hydratant.","price":"29€99","ref":"018"}]';
// Fonction qui permet l'affichage des produits
function addProduct(jData, attr) {
    // La méthode JSON.parse() analyse une chaîne de caractères JSON et construit la valeur JavaScript ou l'objet décrit par cette chaîne
    // Si le type du tableau n'est pas égal à un objet alors on parse le json sinon on récupérer le tableau
    var arrJSON = typeof jData != 'object' ? JSON.parse(jData) : jData;
    // Parcours le tableau afin d'afficher les éléments  du tableau en html
    $.each(arrJSON, function (index, element) {
        $('#' + attr).append('<div class="col-12 col-md-6 col-lg-4 mb-3">' +
            '<figure class="card card-product">' +
            '<div class="img-wrap">' +
            '<img class="img-card" src="' + element.img + '" alt="Image ' + element.title + '" title="image de produit" />' +
            '</div >' +
            '<figcaption class="info-wrap">' +
            '<p class="title text-dots">' + element.title + '</p>' +
            '<p class="desc">' + element.desc + '</p>' +
            '<div class="action-wrap w-100">' +
            '<a array="' + attr + '" id="' + element.ref + '" class="btn btn-success float-right addProduct"><i class="fas fa-cart-plus text-white"></i></a>' +
            '<div class="price-wrap h5">' +
            '<span class="price-new">' + element.price + '</span>' +
            '</div> ' +
            '</div > ' +
            '</figcaption > ' +
            '</figure > ' +
            '</div >');
    });
};
// Appel la fonction en lui attribuant le tableau et un attribut
addProduct(food, 'food');
addProduct(heal, 'heal');
addProduct(accessory, 'accessory');

