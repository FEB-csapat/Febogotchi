<?php
use App\Http\Controllers\UserController;
use App\Http\Controllers\PetController;
use App\Http\Controllers\PetTypeController;
use App\Http\Controllers\ActionController;
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
* General API routes for auth
*/
Route::post('/register', [AuthController::class, "register"])
    ->name("register.store");

Route::post('/authenticate', [AuthController::class, "login"])
    ->name("auth.authenticate");

Route::post('/logout', [AuthController::class, "logout"])
    ->name("auth.logout");

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

/*
* General API routes for user
*/
Route::get('/users', [UserController::class, "index"])
    ->name("users.index");

Route::get('/users/{id}', [UserController::class, "show"])
    ->name("users.show");

/*
* General API routes for pet
*/
Route::get('/pets', [PetController::class, "index"])
    ->name("pets.index");

Route::get('/pets/{id}', [PetController::class, "show"])
    ->name("pets.show");

/*
* General API routes for pet type
*/
Route::get('/pet_types', [PetTypeController::class, "index"])
    ->name("pet_types.index");

Route::get('/pet_types/{id}', [PetTypeController::class, "show"])
    ->name("pet_types.show");

/*
* User API routes for user
*/
Route::middleware(['auth:api', 'role:user|admin'])->group(function () {

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
        ->name("action");
});


/*
* Admin API routes for user
*/
Route::middleware(['auth:api', 'role:admin'])->group(function () {

    Route::post('/admin/pets', [MeController::class, "storePet"])
        ->name("me.pets.store");

    Route::put('/admin/pets/{id}', [MeController::class, "updatePet"])
        ->name("me.pets.update");

    Route::delete('/admin/pets/{id}', [MeController::class, "destroyPet"])
        ->name("me.pets.destroy");


    Route::put('/admin/pets/{id}/action', [MeController::class, "actionPet"])
        ->name("action");


    Route::post('/admin/users', [AdminController::class, "storeUser"])
        ->name("admin.users.store");
    
    Route::put('/admin/users/{id}', [AdminController::class, "updateUser"])
        ->name("admin.users.destroy");
    
    Route::delete('/admin/users/{id}', [AdminController::class, "destroyUser"])
        ->name("admin.users.destroy");
});