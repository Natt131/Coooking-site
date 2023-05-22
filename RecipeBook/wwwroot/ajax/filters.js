//alert("dada");
function deleteRec(id) {
    $.ajax({
        type: "POST",
        // url: "Recipe/ViewCookMinAndCategory",
        url: "Recipe/Delete?=" + id, //все отлчино для одного фильтра
        contentType: "application/json;charset=utf-8;",
        dataType: "json",
        success: function (r) {
            alert("Рецепт удален!");
            window.location.href = r;
        },
        error: function (error) {
            alert("Data can/t get", error);
        }
    });
}

//рабочая страница 
function codeAddress() {
    let obj = '';
    $.ajax({
        type: "GET",
        //url: "Recipe/ViewCookMinAndCategory?=" + cookMin+ category,
        url: "Recipe/ViewAll",
        //url: "Recipe/ViewCookMin?=" + cookMin, //все отлчино для одного фильтра
        contentType: "application/json;charset=utf-8;",
        dataType: "json",
        success: function (result, status, xhr) {
            recipes = result;
            console.log(result);
            // console.log(result[0].Name);
            $('.grid').empty();

            $.each(recipes, function (index, item) {
                var url = '\"\View?RecipeID=' + item.recipeID + '"';

                obj += '<div class=\"grid-item\"' + 'style =\"height: 250px\">' + '<div class=\"info\">' + ' <div>  <a href=\"' + url;
                obj += '\">' + item.name + '</a>';
                obj += '</div> <div class=\"info-text\"> <p>' + item.description + '</p>';
                obj += '</div>';
                obj += ' <div class=\"info-text\" style = \"margin-top: 20px !important\" > ';
                obj += '<a class=\"atuin-btn\" style = \"background-color: green !important; \" href=' + url + '\"> Подробнее </a>';
                obj += '</div>';
                obj += '<div class=\"info-text\" style = \"margin-top: 40px !important; margin-bottom: 30px !important\">';
                //     obj += ' <button class=\"atuin-btn\" onclick="deleteRec('+item.RecipeID+')\" > Удалить </button>';
                obj += '</div>';
                obj += '</div>';
                obj += '</div>';

                $('#grid').html(obj);
            });
        },
        error: function (error) {
            alert("Data can/t get", error);
        }
    });
}
window.onload = codeAddress;

$('#btnCook').click(function () {
    let obj = '';
    let category = $('#select').val();
    let cookMin = $('#select2').val();
    // alert(cookMin)     // $('.emptyMe').empty();
    if ((category === "null") && (cookMin != 0)) {
        $.ajax({
            type: "GET",
            // url: "Recipe/ViewCookMinAndCategory",
            url: "Recipe/ViewCookMin?=" + cookMin, //все отлчино для одного фильтра
            contentType: "application/json;charset=utf-8;",
            dataType: "json",
            success: function (result, status, xhr) {
                recipes = result;
                console.log(result);
                //console.log(result[0].Name);
                $('.grid').empty();

                $.each(recipes, function (index, item) {

                    var url = '\"\View?RecipeID=' + item.recipeID + '"';

                    obj += '<div class=\"grid-item\"' + 'style =\"height: 250px\">' + '<div class=\"info\">' + ' <div>  <a href=\"' + url;
                    obj += '\">' + item.name + '</a>';
                    obj += '</div> <div class=\"info-text\"> <p>' + item.description + '</p>';
                    obj += '</div>';
                    obj += ' <div class=\"info-text\" style = \"margin-top: 20px !important\" > ';
                    obj += '<a class=\"atuin-btn\" style = \"background-color: green !important; \" href=' + url + '\"> Подробнее </a>';
                    obj += '</div>';
                    //obj += '<div class=\"info-text\" style = \"margin-top: 40px !important; margin-bottom: 30px !important\">';
                    //obj += ' <a class=\"atuin-btn\" href=\"\Recipe/Delete?=' + item.recipeID + '\" > Удалить </a>';
                    //obj += '</div>';
                    obj += '</div>';
                    obj += '</div>';

                    $('#grid').html(obj);
                });
            },
            error: function (error) {
                alert("Data can/t get", error);
            }
        });
    }
    else if ((category !== "null") && (cookMin != 0)) {
        $.ajax({
            type: "GET",
            //url: "Recipe/ViewCookMinAndCategory?=" + cookMin+ category,
            url: "Recipe/ViewCookMinAndCategory?cookMin=" + cookMin + "&category=" + category,
            //url: "Recipe/ViewCookMin?=" + cookMin, //все отлчино для одного фильтра
            contentType: "application/json;charset=utf-8;",
            dataType: "json",
            success: function (result, status, xhr) {
                recipes = result;
                console.log(result);
                //  console.log(result[0].Name);
                $('.grid').empty();

                $.each(recipes, function (index, item) {

                    var url = '\"\View?RecipeID=' + item.recipeID + '"';

                    obj += '<div class=\"grid-item\"' + 'style =\"height: 250px\">' + '<div class=\"info\">' + ' <div>  <a href=\"' + url;
                    obj += '\">' + item.name + '</a>';
                    obj += '</div> <div class=\"info-text\"> <p>' + item.description + '</p>';
                    obj += '</div>';
                    obj += ' <div class=\"info-text\" style = \"margin-top: 20px !important\" > ';
                    obj += '<a class=\"atuin-btn\" style = \"background-color: green !important; \" href=' + url + '\"> Подробнее </a>';
                    obj += '</div>';
                    //obj += '<div class=\"info-text\" style = \"margin-top: 40px !important; margin-bottom: 30px !important\">';
                    //obj += ' <a class=\"atuin-btn\" href=\"Recipe\Delete=?\"' + item.recipeID + '\" > Удалить </a>';
                    //obj += '</div>';
                    obj += '</div>';
                    obj += '</div>';

                    $('#grid').html(obj);
                });
            },
            error: function (error) {
                alert("Data can/t get", error);
            }
        });
    }

    else if ((category !== "null") && (cookMin == 0)) {
        $.ajax({
            type: "GET",
            //url: "Recipe/ViewCookMinAndCategory?=" + cookMin+ category,
            url: "Recipe/ViewCookMinAndCategory?cookMin=" + 5000 + "&category=" + category,
            //url: "Recipe/ViewCookMin?=" + cookMin, //все отлчино для одного фильтра
            contentType: "application/json;charset=utf-8;",
            dataType: "json",
            success: function (result, status, xhr) {
                recipes = result;
                console.log(result);
                //  console.log(result[0].Name);
                $('.grid').empty();

                $.each(recipes, function (index, item) {

                    var url = '\"\View?RecipeID=' + item.recipeID + '"';

                    obj += '<div class=\"grid-item\"' + 'style =\"height: 250px\">' + '<div class=\"info\">' + ' <div>  <a href=\"' + url;
                    obj += '\">' + item.name + '</a>';
                    obj += '</div> <div class=\"info-text\"> <p>' + item.description + '</p>';
                    obj += '</div>';
                    obj += ' <div class=\"info-text\" style = \"margin-top: 20px !important\" > ';
                    obj += '<a class=\"atuin-btn\" style = \"background-color: green !important; \" href=' + url + '\"> Подробнее </a>';
                    obj += '</div>';
                    //obj += '<div class=\"info-text\" style = \"margin-top: 40px !important; margin-bottom: 30px !important\">';
                    //obj += ' <a class=\"atuin-btn\" href=\"Recipe\Delete=?\"' + item.recipeID + '\" > Удалить </a>';
                    //obj += '</div>';
                    obj += '</div>';
                    obj += '</div>';

                    $('#grid').html(obj);
                });
            },
            error: function (error) {
                alert("Data can/t get", error);
            }
        });
    }

    else {
        $.ajax({
            type: "GET",
            //url: "Recipe/ViewCookMinAndCategory?=" + cookMin+ category,
            url: "Recipe/ViewAll",
            //url: "Recipe/ViewCookMin?=" + cookMin, //все отлчино для одного фильтра
            contentType: "application/json;charset=utf-8;",
            dataType: "json",
            success: function (result, status, xhr) {
                recipes = result;
                console.log(result);
                // console.log(result[0].Name);
                $('.grid').empty();

                $.each(recipes, function (index, item) {
                    var url = '\"\View?RecipeID=' + item.recipeID + '"';

                    obj += '<div class=\"grid-item\"' + 'style =\"height: 250px\">' + '<div class=\"info\">' + ' <div>  <a href=\"' + url;
                    obj += '\">' + item.name + '</a>';
                    obj += '</div> <div class=\"info-text\"> <p>' + item.description + '</p>';
                    obj += '</div>';
                    obj += ' <div class=\"info-text\" style = \"margin-top: 20px !important\" > ';
                    obj += '<a class=\"atuin-btn\" style = \"background-color: green !important; \" href=' + url + '\"> Подробнее </a>';
                    obj += '</div>';
                    //obj += '<div class=\"info-text\" style = \"margin-top: 40px !important; margin-bottom: 30px !important\">';
                    //obj += ' <a class=\"atuin-btn\" href=\"Recipe\Delete=?\"' + item.recipeID + '\" > Удалить </a>';
                    //obj += '</div>';
                    obj += '</div>';
                    obj += '</div>';

                    $('#grid').html(obj);
                });
            },
            error: function (error) {
                alert("Data can/t get", error);
            }
        });
    }

});