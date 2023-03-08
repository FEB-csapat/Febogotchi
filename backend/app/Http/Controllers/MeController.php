<?php

namespace App\Http\Controllers;

use App\Http\Resources\PetResource;
use App\Http\Resources\UserResource;
use App\Models\Pet;
use Illuminate\Http\Request;
use App\Http\Requests\Pet\StorePetRequest;
use Illuminate\Support\Carbon;

class MeController extends Controller
{

    /**
     * Create a new controller instance.
     *
     * @return void
     */
    public function __construct()
    {
        $this->middleware(['auth:api', 'role:user|admin']);
    }

     /**
     * Display the specified pet.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function showMe(Request $request)
    {
        $user = $request->user();
        return new UserResource($user);
    }

    /**
     * Display a listing of the pets.
     *
     * @return \Illuminate\Http\Response
     */
    public function indexPets(Request $request)
    {
        $pets = $request->user()->pets()->get();
        return PetResource::collection($pets);
    }

    /**
     * Store a newly created pet in storage.
     *
     * @param  App\Http\Requests\Pet\StorePetRequest  $request
     * @return \Illuminate\Http\Response
     */
    public function storePet(StorePetRequest $request)
    {
        $data = $request->validated();
        $data["user_id"] = $request->user()->id;
        $newPet = Pet::create($data);
        return new PetResource($newPet);
    }

    /**
     * Display the specified pet.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function showPet(Request $request, $id)
    {
        $pet = $request->user()->pets()->findOrFail($id);
        return new PetResource($pet);
    }

    /**
     * Update the specified pet in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function updatePet(Request $request, $id)
    {
        $data = $request->validated();
        $pet = Pet::findOrFail($id);
        $pet->updated_at = Carbon::now()->format('Y-m-d H:i:s');
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
        $pet = $request->user()->pets()->findOrFail($id);
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
        $pet = $request->user()->pets()->findOrFail($id);
        
        
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
}
