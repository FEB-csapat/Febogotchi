<?php

use App\Http\Controllers\UniversalController;
use App\Http\Controllers\AdminController;
use App\Http\Controllers\AuthController;
use App\Http\Controllers\MeController;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/


/*
* Universal API routes for authentication
*/
Route::post('/register', [AuthController::class, "register"])
    ->name("register.store");

Route::post('/login', [AuthController::class, "login"])
    ->name("auth.login");

Route::post('/logout', [AuthController::class, "logout"])
    ->name("auth.logout");

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

/*
* Universal API routes for user
*/
Route::get('/users', [UniversalController::class, "indexUsers"])
    ->name("users.index");

Route::get('/users/{id}', [UniversalController::class, "showUser"])
    ->name("users.show");

/*
* Universal API routes for pet
*/
Route::get('/pets', [UniversalController::class, "indexPets"])
    ->name("pets.index");

Route::get('/pets/{id}', [UniversalController::class, "showPet"])
    ->name("pets.show");

/*
* Universal API routes for pet type
*/
Route::get('/pet_types', [UniversalController::class, "indexPetTypes"])
    ->name("pet_types.index");

Route::get('/pet_types/{id}', [UniversalController::class, "showPetType"])
    ->name("pet_types.show");

/*
* Universal API routes for pet status
*/
Route::get('/pet_statuses', [UniversalController::class, "indexPetStatuses"])
    ->name("pet_statuses.index");

Route::get('/pet_statuses/{id}', [UniversalController::class, "showPetStatus"])
    ->name("pet_statuses.show");

/*
* User API routes for user
*/
Route::middleware(['auth:api', 'role:user|admin'])->group(function () {

    Route::get('/me/info', [MeController::class, "showMe"])
        ->name("me.show");

    Route::get('/me/pets', [MeController::class, "indexPets"])

        ->name("me.pets.index");

    Route::get('/me/pets/{id}', [MeController::class, "showPet"])
        ->name("me.pets.show");

    Route::post('/me/pets', [MeController::class, "storePet"])
        ->name("me.pets.store");

    Route::put('/me/pets/{id}', [MeController::class, "updatePet"])
        ->name("me.pets.update");

    Route::delete('/me/pets/{id}', [MeController::class, "destroyPet"])
        ->name("me.pets.destroy");


    Route::put('/me/pets/{id}/action', [MeController::class, "actionPet"])
        ->name("me.pet.saction");
});


/*
* Admin API routes for user
*/
Route::middleware(['auth:api', 'role:admin'])->group(function () {

    Route::post('/admin/pets', [AdminController::class, "storePet"])
        ->name("me.pets.store");

    Route::put('/admin/pets/{id}', [AdminController::class, "updatePet"])
        ->name("me.pets.update");

    Route::delete('/admin/pets/{id}', [AdminController::class, "destroyPet"])
        ->name("me.pets.destroy");


    Route::put('/admin/pets/{id}/action', [AdminController::class, "actionPet"])
        ->name("admin.pets.action");


    Route::post('/admin/users', [AdminController::class, "storeUser"])
        ->name("admin.users.store");
    
    Route::put('/admin/users/{id}', [AdminController::class, "updateUser"])
        ->name("admin.users.destroy");
    
    Route::delete('/admin/users/{id}', [AdminController::class, "destroyUser"])
        ->name("admin.users.destroy");
});