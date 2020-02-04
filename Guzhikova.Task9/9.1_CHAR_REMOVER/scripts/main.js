          function removeDuplicates() {
               var originalText = document.getElementById('original').value;

               var seperators = [' ', '\t', '?', '!', ':', ';', ',', '.'];
               var allSymbols = originalText.split('');
               var words = [];
               var duplicates = [];
               var tempIndex = 0;

               // Creates word's (in lower case format) array from the string
               allSymbols.forEach(function (symbol, i) {
                    var index = seperators.indexOf(symbol);

                    if (index != -1) {
                         words.push(originalText.substr(tempIndex, i - tempIndex).toLowerCase());
                         tempIndex = i + 1;
                    }
               });

               words.push(originalText.substr(tempIndex).toLowerCase());

               // Find duplicate letters in the word (lower case format)
               words.forEach(word => {
                    var symbols = word.split('');

                    symbols.forEach(function (symbol) {
                         var firstIndex = word.indexOf(symbol);
                         var lastIndex = word.lastIndexOf(symbol);
                         if (firstIndex != lastIndex) {
                              duplicates.push(symbol);
                         }
                    });
               });

               duplicates = duplicates.filter((duplicate, index) => 
               {

                    return duplicates.indexOf(duplicate) === index;

               });

               // Delete dublicate letters from original string
               duplicates.forEach(duplicate => {
                    
                    allSymbols = allSymbols.filter(symbol =>
               {

                    return symbol.toLowerCase() != duplicate;

               });
               });
             
               var resultText = allSymbols.join('');
                
               document.getElementById('result').value = resultText;
          }
