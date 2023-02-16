<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class PetResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return array|\Illuminate\Contracts\Support\Arrayable|\JsonSerializable
     */
    public function toArray($request)
    {
        return [
            'id' => $this->id,
          //  'user' => (new UserResource($this->user))
            'pet_type' => (new PetTypeResource($this->petType)),
            
            'name' => $this->name,
            'age' => $this->age,
            'happines' => $this->happines,
            'wellbeing' => $this->wellbeing,
            'fittness' => $this->fittness,
            'thirst' => $this->thirst,
            'hunger' => $this->hunger,
            'birth_date' => $this->birth_date,

         //   'created_at' => $this->created_at,
         //   'updated_at' => $this->updated_at
        ];
    }
}
