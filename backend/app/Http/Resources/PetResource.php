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
            'happiness' => $this->happiness,
            'wellbeing' => $this->wellbeing,
            'fittness' => $this->fittness,
            'sate' => $this->sate,
            'energy' => $this->energy,
            'birth_date' => $this->birth_date,

            'is_alive' => $this->is_alive,

         //   'created_at' => $this->created_at,
         //   'updated_at' => $this->updated_at
        ];
    }
}
