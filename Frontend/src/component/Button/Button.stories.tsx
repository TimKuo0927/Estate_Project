import type { Meta, StoryObj } from '@storybook/react';
import Button from './Button';

const meta: Meta<typeof Button> = {
  title: 'Component/Button',
  component: Button,
  tags: ['autodocs'], // Optional: enables Storybook's auto docs
};

export default meta;
type Story = StoryObj<typeof Button>;

export const Default: Story = {
  render: () => <Button label={'asd'} onClick={() => alert('Button clicked!')} />,
};

export const Secondary: Story = {
  render: () => <Button label={'label'} variant="secondary" />,
};

export const Danger: Story = {
  render: () => <Button label={'label'} variant="danger" />,
};

export const outline: Story = {
  render: () => <Button label={'label'} variant="outline" />,
};

export const Disabled: Story = {
  render: () => <Button label={'label'} disabled={true} />,
};
