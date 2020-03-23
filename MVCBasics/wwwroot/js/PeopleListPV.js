"use strict";

//$(document).ready(function () {

    
//    //Fixen är att flytta ut denna utanför ready
//    deletePerson(id);


//    editPerson(id);


//    /*
//    $("#btnPartialEdit").click(function (e) {
//        e.preventDefault(); var _this = $(this);
//        $.get(_this.attr("href"), function (res) {
//            $('#' + _this.data("target")).html(res);
//        });
//    });
//    */

//});




//LOGIK KRING JAVASCRIPT:
//KNAPP i PARTIALVIEW initierar JAVASCRIPT 
//JavaskripteT/Json-request (exempelvis $.get) ropar på CONTROLLERN, unikt id bifogas
//CONTROLLERN försöker via SERVICES och vidare iva REPOSITORY göra ändringen i DB och flaggar för om denna lyckats/inte lyckats - status "skickas upp/tillbaka" till JAVASKRIPTET.
//Scriptet känner på resultatet från Controllern - .done eller.fail (eller "if (status == "success")".


//Fixen är att flytta ut denna utanför ready

function deletePersonPV(id) {                             //metoden har id som inparameter

    $.get("RemovePV/" + id, function (data, status) {     //REMOVE är här URL:en, DET ÄR Action skall heta i CONTROLLERN - det är din man hoppar härnäst

        console.log("Status: " + status);               //loggar så att jag ser status  //VI HAR NU RADERAT PÅ SERVERSIDAN´(DATABASEN ELLER LISTAN)

        if (status == "success") {
            $("#peopleListId" + id).remove();           //slår ihop id-text(knappnamn) med det unika id:t - och gör EN JQuery remove på på partialViewn - på webbsidan
        }
        //if-satsen kan ersättas med done/fail, se uffes Ajax projekt
    });
};



//function editPersonPV(id) {

//    $.post("EditPV/" + id, function (data, status)                         //url
//        {                                      //data 
//            Name: $("#Name").val(),
//            Telephone: $("#PhoneNumber").val(),
//            City: $("#City").val()
//    }

//        , function (data, status) {                 //respons from server

//            console.log("Data: " + data + "\nStatus: " + status);

//            $("#peolpeList").editPV(data);

//        })
//        .done(function () {                         //what to do if it was a sucsses
//            $("#Name").val("");
//            $("#Number").val("");
//            $("#City").val("");
//        })
//        .fail(function () {                         //what to do if it was a error
//            console.log("create error");
//        });


////}


//function editPerson(id) {         
//    $.get("Edit/" + id, function (data, status) {

//        console.log("Status: " + status);

//        if (status == "success") {
//            $("#peopleListId" + id).edit();          
//        }
//    });


//};