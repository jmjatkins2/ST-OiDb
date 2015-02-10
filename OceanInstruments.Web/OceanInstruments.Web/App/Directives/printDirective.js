(function () {
    (function (angular) {
        'use strict';

        function printDirective() {
            var printSection = document.getElementById('printSection');

            // if there is no printing section, create one
            if (!printSection) {
                printSection = document.createElement('div');
                printSection.id = 'printSection';
                document.body.appendChild(printSection);

                var printHeader = "<img id='logo' src='../../Content/Images/oceaninstruments_logo_side_with_text.png' alt='Ocean Instruments' />" +
                    "<div id='elementToPrint'/>";
                $(printSection).append(printHeader);
            }

            var elemToPrint = document.getElementById('elementToPrint');

            function link(scope, element, attrs) {
                element.on('click', function () {
                    var elemToPrint = document.getElementById(attrs.printElementId);
                    if (elemToPrint) {
                        printElement(elemToPrint);
                        window.print();
                    }
                });

                window.onafterprint = afterPrint();
                //chrome has no onafterprint, use below
                if (window.matchMedia) {
                    var mediaQueryList = window.matchMedia('print');
                    mediaQueryList.addListener(function (mql) {
                        if (!mql.matches) {
                            afterPrint();
                        }
                    });
                }
            }

            function printElement(elem) {
                // clones the element you want to print
                var domClone = elem.cloneNode(true);
                elemToPrint.appendChild(domClone);
            }

            function afterPrint() {
                // clean the print section before adding new content
                elemToPrint.innerHTML = '';
            }

            return {
                link: link,
                restrict: 'A'
            };
        }

        app.directive('ngPrint', [printDirective]);
    }(window.angular));

})();