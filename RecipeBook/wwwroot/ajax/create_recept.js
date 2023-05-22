
//добавление полей для игредиента
var count = 0;
buttonIngr = document.getElementById("button_ingr");// buttonIngr.onclick = function
function file() {
    this.count++;
    document.getElementById("new").insertAdjacentHTML( //txtItem
        "afterbegin",
        `<div class="row" style="padding-left:200px">
                <div class="main-form__item col-md-3">
                                <label class="main-form__label" name="ingrInput">Количество: </label>
                                                <input class="main-form__input" style="width:100px !important" id="amoun`+ this.count + `" />
                                 </div>
                                   <div class="main-form__item col-md-3">
                                                <label class="main-form__label">Единицы измерения: </label>
                                        <input  class="main-form__input"  style="width:100px !important" id="unit`+ this.count + `" />
                                     </div>
                                    <div class="main-form__item col-md-3">
                                        <label class="main-form__label">Название: </label>
                                        <input class="main-form__input" style="width:100px !important" id="nameing`+ this.count + `" />
                                    </div></div>`
    );
}

//ДОБАВЛЕНИЕ AJAX
$("body").on("click", "#btn", function () {

    var ingrs = [];
    var rec = {};

    //   console.log("len",document.getElementsByName("ingrInput").length);
    var name = $("#Name");
    var description = $("#Description");
    var servings = $("#Sevings");
    var prepMin = $("#PrepMin");
    var cookMin = $("#CookMin");
    var directions = $("#Directions");

    var category = $("#Category");

    rec.Name = name.val();
    rec.Description = description.val();
    rec.Servings = 5;
    rec.CookMinutes = cookMin.val();
    rec.PrepMinutes = prepMin.val();
    rec.Directions = directions.val();
    rec.Category = category.val();
    let i = 0;
    let ing = {};
    // console.log(this.count);
    while (i < document.getElementsByName("ingrInput").length) {
        let ing = {};
        ing.Name = $("#nameing" + i).val();
        ing.Unit = $("#unit" + i).val();
        ing.Amount = $("#amoun" + i).val();
        ingrs.push(ing);
        i++;
    }
    console.log(ingrs);

    var json = JSON.stringify({
        Recipe: rec,
        Ingredients: ingrs
    });

    console.log(json);

    $.ajax({
        type: "POST",
        url: "Recipe/CreateRec",
        data: json,//JSON.stringify(model),
        contentType: "application/json",
        dataType: "json",
        success: function (r) {
            window.location.href = r;
        },
        error: function (xhr) {
            //Do Something to handle error
            alert("xtn ytwwwwwwww nj", xhr),
                window.location.href = "Recipe/List".redirect;
        }
    });
    //
});