var gulp = require('gulp');
var tslint = require('gulp-tslint');
var del = require('del');
var exec = require('child_process').exec;

gulp.task('vet', function() {
    return gulp.src('./src/**/*.ts')
    .pipe(tslint())
    .pipe(tslint.report());
});

gulp.task('clean', function() {
    return del('./dist/');
});

gulp.task('compile', ['vet', 'clean'], function(done) {
    exec('tsc -p src', function (err, stdout, stderr) {
        console.log(stdout);
        done();
    });
});

gulp.task('compile-watch', ['compile'], function() {
    return gulp.watch(['src/**/*.ts'], ['compile']);
});