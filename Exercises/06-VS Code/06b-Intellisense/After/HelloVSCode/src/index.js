"use strict";
var _ = require("lodash");
function skewer(input) {
    var output = _.kebabCase(input);
    return output;
}
var message = skewer("EnableJavacriptIntellisense");
console.log(message);
