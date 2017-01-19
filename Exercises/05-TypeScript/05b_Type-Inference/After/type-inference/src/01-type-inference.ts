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
        type: string;
        talk() {
            console.log("Woof");
        }
    }

    let student = new Student();
    let teacher = new Faculty();
    let mascot = new Mascot();

    // Create an array of people
    let people = [student, teacher];

    console.log("People talking:");
    people[0].talk();
    people[1].talk();

    // Create an array of mammals
    let mammals = [student, teacher, mascot];

    console.log("\nMammals talking:");
    mammals[0].talk();
    mammals[1].talk();
    mammals[2].talk();
}