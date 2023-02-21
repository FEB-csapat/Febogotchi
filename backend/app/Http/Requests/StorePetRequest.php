<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;


class StorePetRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     *
     * @return bool
     */
    public function authorize()
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, mixed>
     */
    public function rules()
    {
        return [
          //  'user' => (new UserResource($this->user))
            'pet_type_id' => "required|numeric|exists:pet_types,id",
            
            'name' => "required|min:2|max:20",
        ];
    }
}
