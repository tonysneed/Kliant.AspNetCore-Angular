import * as _ from "lodash";

function skewer(input: string): string {
    let output = _.kebabCase(input);
    return output;
}

let message = skewer("EnableJavacriptIntellisense");
console.log(message);
