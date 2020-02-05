
function calculate() {

     var inputMath = document.getElementById('math');
     var errorMessage = document.getElementsByClassName('error')[0];
     var resultInfo = document.getElementById('result');

     errorMessage.textContent = '';
     resultInfo.textContent = '';

     var regex = /^[-+]?\d+[.]?\d*(( ?[+-/*] ?)([-+]?\d+[.]?\d*))* ?=$/;
     var regexWithoutEqualSign = /^[-+]?\d+[.]?\d*(( ?[+-/*] ?)([-+]?\d+[.]?\d*))* ?$/;

     var mathString = inputMath.value;
     var number;
     var sign = '';
     var result = 0;

     // Checking input format. Correction, if possible.
     if (!regex.test(mathString)) {
          if (regexWithoutEqualSign.test(mathString)) {
               console.warn('Отсутствует знак "=". Добавлен автоматически.');
               mathString += '=';
               inputMath.value += '=';
          } else {
               errorMessage.textContent = "Неверный формат!";
          }
     }

     // Calculation if the input data is correct
     if (regex.test(mathString)) {
          mathString = mathString.replace(/ /g, '');

          var numbersRegex = /[-+]?\d+[.]?\d*( ?[+-/*] ?)?/g;
          var signRegex = /[-+]?\d+[.]?\d*/;

          var parts = mathString.match(numbersRegex);

          parts.forEach(function (part, index) {
               number = (index < parts.length - 1)
                    ? parseFloat(part.substring(0, part.length - 1))
                    : parseFloat(part);

               switch (sign) {
                    case '+':
                         result += number;
                         break;
                    case '-':
                         result -= number;
                         break;
                    case '*':
                         result *= number;
                         break;
                    case '/':
                         result /= number;
                         break;
                    default:
                         result = number;
               }
               sign = part.slice(-1);
          });

          // Checking division by zero
          if (result != NaN && result != Infinity && result != -Infinity) {
               resultInfo.textContent = result.toFixed(2);
          } else {
               errorMessage.textContent = "Деление на ноль недопустимо!";
          }
     }
}

