<?php

namespace App\Http\Controllers;

use App\Http\Resources\PetResource;
use App\Http\Resources\UserResource;
use App\Models\Pet;
use Illuminate\Http\Request;
use App\Http\Requests\Pet\AdminStorePetRequest;
use App\Http\Requests\Pet\AdminUpdatePetRequest;
use App\Http\Requests\User\StoreUserRequest;
use App\Http\Requests\User\UpdateUserRequest;
use App\Models\User;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Carbon;

class AdminController extends Controller
{

    /**
     * Create a new controller instance.
     *
     * @return void
     */
    public function __construct()
    {
        $this->middleware(['auth:api', 'role:admin']);
    }


    /**
     * Store a newly created pet in storage.
     *
     * @param  App\Http\Requests\AdminStorePetRequest  $request
     * @return \Illuminate\Http\Response
     */
    public function storePet(AdminStorePetRequest $request)
    {
        $data = $request->validated();
        $newPet = Pet::create($data);
        return new PetResource($newPet);
    }

    /**
     * Update the specified pet in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function updatePet(AdminUpdatePetRequest $request, $id)
    {
        $data = $request->validated();
        $pet = Pet::findOrFail($id);
        if($pet->update($data)){
            return new PetResource($pet);
        }
    }

    /**
     * Remove the specified pet from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroyPet(Request $request, $id)
    {
        $pet = Pet::findOrFail($id);
        $pet->delete();
    }

    /**
     * Perform action by pet
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function actionPet(Request $request, $id)
    {
        $pet = Pet::findOrFail($id);
        
        $result = json_decode($request->getContent(), true);

        // TODO make validation for response body
        switch(strtolower($result['action'])){
            case 'hunt':
                $pet->hunt();
                break;
            case 'play':
                $pet->play();
                break;
            case 'cure':
                $pet->cure();
                break;
            case 'eat':
                $pet->eat();
                break;
            case 'sleep':
                $pet->sleep();
                break;
            default:
                abort(422, "Unprocessable Entity");
                break;
        }
        return new PetResource($pet);
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  App\Http\Requests\User\StoreUserRequest  $request
     * @return \Illuminate\Http\Response
     */
    public function storeUser(StoreUserRequest $request)
    {
        $data = $request->validated();
        $request['password'] = Hash::make($request['password']);
        $newUser = User::create($data);
        $newUser->assignUserRole();
        return new UserResource($newUser);
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\UpdateUserRequest  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function updateUser(UpdateUserRequest $request, $id)
    {
        $data = $request->validated();
        $user = User::findOrFail($id);
        $user->updated_at = Carbon::now()->format('Y-m-d H:i:s');
        if($user->update($data)){
            return new UserResource($user);
        }
    }

    /**
     * Remove the specified user from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroyUser(Request $request, $id)
    {
        if($id == $request->user()->id){
            abort(403, "Cannot delete admin");
        }
        $user = User::findOrFail($id);
        $user->delete();
    }
}
