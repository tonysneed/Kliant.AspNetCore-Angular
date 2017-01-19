namespace type_inference {

    class Person {
        talk() {
            console.log("Hello");
        }
    }

    class Student extends Person {
    }

    class Faculty extends Person {
    }

    class Mascot {
    }

    let student = new Student();
    let teacher = new Faculty();
    let mascot = new Mascot();
}