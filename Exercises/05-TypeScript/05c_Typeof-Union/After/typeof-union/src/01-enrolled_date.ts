namespace enrolled_date {

    class Person {
        name: string;
        age: number;
    }

    class Student extends Person {
        private enrolled: Date;
        setEnrolled(date: Date) {
            this.enrolled = date;
        }
        getEnrolled(): string {
            return this.enrolled.toDateString();
        }
    }

    let student = new Student();
    student.name = "Sue";
    student.age = 20;
    student.setEnrolled(new Date());

    console.log(`Student named ${student.name}, age ${student.age}, ` +
        `enrolled on: ${student.getEnrolled()}`);
}