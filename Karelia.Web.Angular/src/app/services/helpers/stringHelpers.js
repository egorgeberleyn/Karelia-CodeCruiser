const specialCharacters = /\_|\,|\.|\s|\<|\>|\&|\%|\;|\#|\"|\'|\?|\*|\[|\]|\-|\+|\~|\!|\@|\||\/|\\/g;
const upperCase = /[A-Z]/;

export function normalize(str) {
    let result = '';
    if (str) {
        str = str.replace(specialCharacters, '-');
    }
    let first = true;
    for (let a of str) {
        if (a.match(upperCase) && first === false) {
            result += '-';
        }
        result += a.toLowerCase();
        first = false;
    }
    return result;
}

