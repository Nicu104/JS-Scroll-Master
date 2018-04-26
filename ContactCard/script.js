var clicked = false;

function beautify() {

    $(".box").css("width", "230px");
    $(".box").css("display", "inline-block");
    $(".box").css("height", "100px");
    $(".box").css("border", "2px solid black");
    $(".box").css("background-color", "beige");
    $(".box").css("margin", "10px");
    $(".box").css("padding", "0px");
    $(".box").css("text-align", "center");

    $("p").css("margin", "10px 10px");
    $("p").css("padding", "0px");
        $("p.hidden").hide();

    $(".box").click(function(event){
        event.stopPropagation();
            $(this).children("h2").hide();
            $(this).children("p").hide();
            $(this).children("p.hidden").show();
     
 });
        $(".box").dblclick(function(event){
            event.stopPropagation();
            
            $(this).children("h2").show();
            $(this).children("p").show();
            $(this).children("p.hidden").hide();
        });
   
}

$(document).ready(function () {

    $("#card-form").submit(function () {
        var fname = $("#fName").val();
        var lname = $("#lName").val();
        var description = $("#textbox").val();
        $("#cards").append(" <div class='box'> <h2 >" + fname + " " + lname + "</h2> <p>Click for description</p> <p class='hidden'>" + description + "</p></div> ");
        beautify();
       return false;
    });

});