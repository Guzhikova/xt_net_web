function allToRight(button) {
     var leftSelect = button.parentNode.previousElementSibling;
     var rightSelect = button.parentNode.nextElementSibling;

     var leftOptions = leftSelect.options;

     for (var i = 0; i < leftOptions.length; i++) {
          var option = new Option(leftOptions[i].textContent, leftOptions[i].value);
          rightSelect.append(option);
     }

     leftOptions.length = 0;
}

function allToLeft(button) {
     var leftSelect = button.parentNode.previousElementSibling;
     var rightSelect = button.parentNode.nextElementSibling;     

     var rightOptions = rightSelect.options;

     for (var i = 0; i < rightOptions.length; i++) {
          var option = new Option(rightOptions[i].textContent, rightOptions[i].value);
          leftSelect.append(option);
     }

     rightOptions.length = 0;
}

function elementsToRight(button) {
     var leftSelect = button.parentNode.previousElementSibling;
     var rightSelect = button.parentNode.nextElementSibling;
     var errorElement = document.getElementById('selectError');

     var selected = leftSelect.selectedOptions;
     var options = leftSelect.options;

     errorElement.textContent = ' ';

     if (selected.length == 0) {
          errorElement.textContent = "Sorry! Nothing selected or list is empty!";
     } else 
     {
          for (var i = 0; i < selected.length; i++) {
               var newOption = new Option(selected[i].textContent, selected[i].value);
               rightSelect.append(newOption);
          }

          for (var i = options.length - 1; i >= 0; i--) {
               if (options[i].selected) 
               {
                    options[i].selected = false;
                    leftSelect.removeChild(options[i]);
               }
          }
     }
}

function elementsToLeft(button) {
     var leftSelect = button.parentNode.previousElementSibling;
     var rightSelect = button.parentNode.nextElementSibling;
     var errorElement = document.getElementById('selectError');

     var selected = rightSelect.selectedOptions;
     var options = rightSelect.options;

     errorElement.textContent = '';

     if (selected.length == 0) {
          errorElement.textContent = "Sorry! Nothing selected or list is empty!";
     } else 
     {
          for (var i = 0; i < selected.length; i++) {
               var newOption = new Option(selected[i].textContent, selected[i].value);
               leftSelect.append(newOption);
          }

          for (var i = options.length - 1; i >= 0; i--) {
               if (options[i].selected) 
               {
                    options[i].selected = false;
                    rightSelect.removeChild(options[i]);
               }
          }
     }
}
