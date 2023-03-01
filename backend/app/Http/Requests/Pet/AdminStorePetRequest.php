<?php

namespace App\Http\Requests\Pet;

use Illuminate\Foundation\Http\FormRequest;


class AdminStorePetRequest extends FormRequest
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
            'user_id' => 'required|numeric|exists:users,id',
            'pet_type_id' => "required|numeric|exists:pet_types,id",
            'name' => "required|min:2|max:20",
        ];
    }
}
