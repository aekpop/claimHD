var inputElement = document.querySelector("#material-input");
var inputElements = document.querySelectorAll('.material-input');

inputElements.forEach(function(inputElement){
    inputElement.addEventListener('focus', function(e){
        var label = e.target.nextSibling.nextSibling;
        label.classList.toggle("floating");
    });
    inputElement.addEventListener('blur', function(e){
        var label = e.target.nextSibling.nextSibling;
        label.classList.toggle("floating");
    });
})